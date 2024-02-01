using AutoMapper;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Entities;
using Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Controllers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Coso;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.File;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.FileType;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Firm;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Process;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskMitigationControl;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskPossibleOptimization;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskScore;

namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Mappings;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<Coso, CosoViewModel>();
        CreateMap<CosoCreateModel, Coso>();
        CreateMap<CosoUpdateModel, Coso>();

        CreateMap<Department, DepartmentViewModel>();
        CreateMap<DepartmentCreateModel, Department>();
        CreateMap<DepartmentUpdateModel, Department>();

        CreateMap<File, FileViewModel>();

        CreateMap<FileType, FileTypeViewModel>();
        CreateMap<FileTypeCreateModel, FileType>();
        CreateMap<FileTypeUpdateModel, FileType>();

        CreateMap<Firm, FirmViewModel>();
        CreateMap<FirmCreateModel, Firm>();
        CreateMap<FirmUpdateModel, Firm>();

        CreateMap<MitigationControl, MitigationControlViewModel>();
        CreateMap<MitigationControlCreateModel, MitigationControl>();
        CreateMap<MitigationControlUpdateModel, MitigationControl>();

        CreateMap<Process, ProcessViewModel>();
        CreateMap<ProcessCreateModel, Process>();
        CreateMap<ProcessUpdateModel, Process>();

        CreateMap<Risk, RiskViewModel>();
        CreateMap<Risk, RiskIndexViewModel>();
        CreateMap<RiskCreateModel, Risk>();
        CreateMap<RiskUpdateModel, Risk>();
        CreateMap<RiskCsvModel, Risk>();

        CreateMap<RiskMitigationControl, RiskMitigationControlViewModel>();
        CreateMap<RiskMitigationControlUpdateModel, RiskMitigationControl>();

        CreateMap<RiskPossibleOptimization, RiskPossibleOptimizationViewModel>();
        CreateMap<RiskPossibleOptimizationUpdateModel, RiskPossibleOptimization>();

        CreateMap<RiskScore, RiskScoreViewModel>();
        CreateMap<RiskScoreCreateModel, RiskScore>();
        CreateMap<RiskScoreUpdateModel, RiskScore>();
    }
}