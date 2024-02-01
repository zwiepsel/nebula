using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CsvHelper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;
using Nebula.Clients.APC.Apps.RMP.Shared.Enums;
using Nebula.Shared.Api.Controllers;
using Nebula.Shared.Extensions;

namespace Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;

[ApiController]
[Route("import")]
[AllowAnonymous]
public class ImportController : AppBaseController
{
    private readonly ICosoRepository cosoRepository;
    private readonly IFirmRepository firmRepository;
    private readonly IMitigationControlRepository mitigationControlRepository;
    private readonly IRiskMitigationControlRepository riskMitigationControlRepository;
    private readonly IRiskRepository riskRepository;
    private readonly IProcessRepository processRepository;
    private readonly IRiskScoreRepository riskScoreRepository;
    private readonly IWebHostEnvironment webHostEnvironment;

    public ImportController(IMediator mediator,
        IMapper mapper,
        IWebHostEnvironment webHostEnvironment,
        IRiskRepository riskRepository,
        IProcessRepository processRepository,
        ICosoRepository cosoRepository,
        IFirmRepository firmRepository,
        IRiskScoreRepository riskScoreRepository,
        IMitigationControlRepository mitigationControlRepository,
        IRiskMitigationControlRepository riskMitigationControlRepository) : base(mediator, mapper)
    {
        this.webHostEnvironment = webHostEnvironment;
        this.riskRepository = riskRepository;
        this.processRepository = processRepository;
        this.cosoRepository = cosoRepository;
        this.firmRepository = firmRepository;
        this.riskScoreRepository = riskScoreRepository;
        this.mitigationControlRepository = mitigationControlRepository;
        this.riskMitigationControlRepository = riskMitigationControlRepository;
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var path = Path.Combine(webHostEnvironment.ContentRootPath, "var", "Import_Rev_MT.csv");
        using var reader = new StreamReader(path);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

        // @todo possible optimizations

        var riskCsvModels = csvReader.GetRecords<RiskCsvModel>().ToList();

        var processes = await processRepository.FindAll();
        var cosos = await cosoRepository.FindAll();
        var firms = await firmRepository.FindAll();
        var riskScores = await riskScoreRepository.FindAll();
        var mitigationControls = await mitigationControlRepository.FindAll();

        foreach (var riskCsvModel in riskCsvModels)
        {
            var risk = Mapper.Map<Risk>(riskCsvModel);
            var process = processes.FirstOrDefault(process => process.Name == riskCsvModel.ProcessName);

            if (process == null)
            {
                process = new Process { Name = riskCsvModel.ProcessName };

                processRepository.Add(process);
                await processRepository.SaveChangesAsync();

                processes.Add(process);
            }

            risk.ProcessId = process.Id;

            if (!riskCsvModel.CosoName.IsNullOrWhitespace())
            {
                var coso = cosos.FirstOrDefault(c => c.Name == riskCsvModel.CosoName);

                if (coso == null)
                {
                    coso = new Coso { Name = riskCsvModel.CosoName! };

                    cosoRepository.Add(coso);
                    await cosoRepository.SaveChangesAsync();

                    cosos.Add(coso);
                }

                risk.CosoId = coso.Id;
            }

            if (!riskCsvModel.FirmName.IsNullOrWhitespace())
            {
                var firm = firms.FirstOrDefault(f => f.Name == riskCsvModel.FirmName);

                if (firm == null)
                {
                    firm = new Firm { Name = riskCsvModel.FirmName! };

                    firmRepository.Add(firm);
                    await firmRepository.SaveChangesAsync();

                    firms.Add(firm);
                }

                risk.FirmId = firm.Id;
            }

            if (riskCsvModel.RiskScoreType != null)
            {
                var inherentRiskScoreFrequency = riskScores.FirstOrDefault(rs =>
                    rs.Type == riskCsvModel.RiskScoreType && rs.Score == riskCsvModel.InherentRiskFrequency);
                var inherentRiskScoreImpact = riskScores.FirstOrDefault(rs =>
                    rs.Type == riskCsvModel.RiskScoreType && rs.Score == riskCsvModel.InherentRiskImpact);
                var residualRiskScoreFrequency = riskScores.FirstOrDefault(rs =>
                    rs.Type == riskCsvModel.RiskScoreType && rs.Score == riskCsvModel.ResidualRiskFrequency);
                var residualRiskScoreImpact = riskScores.FirstOrDefault(rs =>
                    rs.Type == riskCsvModel.RiskScoreType && rs.Score == riskCsvModel.ResidualRiskImpact);

                if (inherentRiskScoreFrequency != null) risk.InherentFrequencyRiskScoreId = inherentRiskScoreFrequency.Id;

                if (inherentRiskScoreImpact != null) risk.InherentImpactRiskScoreId = inherentRiskScoreImpact.Id;

                if (residualRiskScoreFrequency != null) risk.ResidualFrequencyRiskScoreId = residualRiskScoreFrequency.Id;

                if (residualRiskScoreImpact != null) risk.ResidualImpactRiskScoreId = residualRiskScoreImpact.Id;
            }

            riskRepository.Add(risk);
            await riskRepository.SaveChangesAsync();

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl1,
                riskCsvModel.MitigatingControlType1,
                riskCsvModel.MitigatingControlImpact1,
                riskCsvModel.MitigatingControlFrequency1);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl2,
                riskCsvModel.MitigatingControlType2,
                riskCsvModel.MitigatingControlImpact2,
                riskCsvModel.MitigatingControlFrequency2);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl3,
                riskCsvModel.MitigatingControlType3,
                riskCsvModel.MitigatingControlImpact3,
                riskCsvModel.MitigatingControlFrequency3);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl4,
                riskCsvModel.MitigatingControlType4,
                riskCsvModel.MitigatingControlImpact4,
                riskCsvModel.MitigatingControlFrequency4);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl5,
                riskCsvModel.MitigatingControlType5,
                riskCsvModel.MitigatingControlImpact5,
                riskCsvModel.MitigatingControlFrequency5);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl6,
                riskCsvModel.MitigatingControlType6,
                riskCsvModel.MitigatingControlImpact6,
                riskCsvModel.MitigatingControlFrequency6);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl7,
                riskCsvModel.MitigatingControlType7,
                riskCsvModel.MitigatingControlImpact7,
                riskCsvModel.MitigatingControlFrequency7);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl8,
                riskCsvModel.MitigatingControlType8,
                riskCsvModel.MitigatingControlImpact8,
                riskCsvModel.MitigatingControlFrequency8);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl9,
                riskCsvModel.MitigatingControlType9,
                riskCsvModel.MitigatingControlImpact9,
                riskCsvModel.MitigatingControlFrequency9);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl10,
                riskCsvModel.MitigatingControlType10,
                riskCsvModel.MitigatingControlImpact10,
                riskCsvModel.MitigatingControlFrequency10);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl11,
                riskCsvModel.MitigatingControlType11,
                riskCsvModel.MitigatingControlImpact11,
                riskCsvModel.MitigatingControlFrequency11);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl12,
                "Preventive",
                null,
                null);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl13,
                "Preventive",
                null,
                null);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl14,
                "Preventive",
                null,
                null);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl15,
                "Preventive",
                null,
                null);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl16,
                "Preventive",
                null,
                null);

            await ProcessMitigationControl(mitigationControls,
                risk,
                riskCsvModel.MitigatingControl17,
                "Preventive",
                null,
                null);
        }

        return Ok();
    }

    private async Task ProcessMitigationControl(IList<MitigationControl> mitigationControls,
        Risk risk,
        string? name,
        string? type,
        string? impact,
        string? frequency)
    {
        if (name.IsNullOrWhitespace() || type.IsNullOrWhitespace())
        {
            return;
        }

        var mitigationControl = mitigationControls.FirstOrDefault(f => f.Name == name);

        if (mitigationControl == null)
        {
            mitigationControl = new MitigationControl
            {
                Name = name!,
                ShortName = "",
                Description = "",
                ControlType = (MitigationControlType)Enum.Parse(typeof(MitigationControlType), type!),
                Trigger = MitigationControlTrigger.Daily
            };

            mitigationControlRepository.Add(mitigationControl);
            await mitigationControlRepository.SaveChangesAsync();

            mitigationControls.Add(mitigationControl);
        }

        var score = 0;

        if (!impact.IsNullOrWhitespace() && !frequency.IsNullOrWhitespace())
        {
            var impactScore = int.Parse(impact!);
            var frequencyScore = int.Parse(frequency!);

            score = (int)Math.Round((decimal)(impactScore + frequencyScore) / 2);
        }

        var riskMitigationControl = new RiskMitigationControl
        {
            RiskId = risk.Id,
            MitigationControlId = mitigationControl.Id,
            Score = (RiskMitigationControlScore)score
        };

        riskMitigationControlRepository.Add(riskMitigationControl);
        await riskMitigationControlRepository.SaveChangesAsync();
    }
}

public class RiskCsvModel
{
    private string? context;
    private string? objective;

    public string Name { get; set; } = null!;
    public string ProcessName { get; set; } = null!;
    public string? ShortName { get; set; }
    public string? StrategicTarget { get; set; }

    public string? Context
    {
        get => $"<p>{context}</p>";
        set => context = value;
    }

    public string? Objective
    {
        get => $"<p>{objective}</p>";
        set => objective = value;
    }

    public DateTime? IdentificationDate { get; set; }
    public DateTime? ReviewDate { get; set; }
    public RiskScoreType? RiskScoreType { get; set; }

    public int? InherentRiskFrequency { get; set; }
    public int? InherentRiskImpact { get; set; }
    public int? ResidualRiskFrequency { get; set; }
    public int? ResidualRiskImpact { get; set; }

    public string? CosoName { get; set; }
    public string? FirmName { get; set; }

    public string? MitigatingControl1 { get; set; }
    public string? MitigatingControlType1 { get; set; }
    public string? MitigatingControlImpact1 { get; set; }
    public string? MitigatingControlFrequency1 { get; set; }

    public string? MitigatingControl2 { get; set; }
    public string? MitigatingControlType2 { get; set; }
    public string? MitigatingControlImpact2 { get; set; }
    public string? MitigatingControlFrequency2 { get; set; }

    public string? MitigatingControl3 { get; set; }
    public string? MitigatingControlType3 { get; set; }
    public string? MitigatingControlImpact3 { get; set; }
    public string? MitigatingControlFrequency3 { get; set; }

    public string? MitigatingControl4 { get; set; }
    public string? MitigatingControlType4 { get; set; }
    public string? MitigatingControlImpact4 { get; set; }
    public string? MitigatingControlFrequency4 { get; set; }

    public string? MitigatingControl5 { get; set; }
    public string? MitigatingControlType5 { get; set; }
    public string? MitigatingControlImpact5 { get; set; }
    public string? MitigatingControlFrequency5 { get; set; }

    public string? MitigatingControl6 { get; set; }
    public string? MitigatingControlType6 { get; set; }
    public string? MitigatingControlImpact6 { get; set; }
    public string? MitigatingControlFrequency6 { get; set; }

    public string? MitigatingControl7 { get; set; }
    public string? MitigatingControlType7 { get; set; }
    public string? MitigatingControlImpact7 { get; set; }
    public string? MitigatingControlFrequency7 { get; set; }

    public string? MitigatingControl8 { get; set; }
    public string? MitigatingControlType8 { get; set; }
    public string? MitigatingControlImpact8 { get; set; }
    public string? MitigatingControlFrequency8 { get; set; }

    public string? MitigatingControl9 { get; set; }
    public string? MitigatingControlType9 { get; set; }
    public string? MitigatingControlImpact9 { get; set; }
    public string? MitigatingControlFrequency9 { get; set; }

    public string? MitigatingControl10 { get; set; }
    public string? MitigatingControlType10 { get; set; }
    public string? MitigatingControlImpact10 { get; set; }
    public string? MitigatingControlFrequency10 { get; set; }

    public string? MitigatingControl11 { get; set; }
    public string? MitigatingControlType11 { get; set; }
    public string? MitigatingControlImpact11 { get; set; }
    public string? MitigatingControlFrequency11 { get; set; }

    public string? MitigatingControl12 { get; set; }
    public string? MitigatingControl13 { get; set; }
    public string? MitigatingControl14 { get; set; }
    public string? MitigatingControl15 { get; set; }
    public string? MitigatingControl16 { get; set; }
    public string? MitigatingControl17 { get; set; }
}