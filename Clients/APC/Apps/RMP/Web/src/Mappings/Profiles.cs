using AutoMapper;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Coso;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Department;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.FileType;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Firm;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.MitigationControl;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Process;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Risk;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskMitigationControl;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskPossibleOptimization;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.RiskScore;

namespace Nebula.Clients.APC.Apps.RMP.Web.Mappings;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<CosoViewModel, CosoUpdateModel>();
        CreateMap<CosoUpdateModel, CosoViewModel>();

        CreateMap<DepartmentViewModel, DepartmentUpdateModel>();
        CreateMap<DepartmentUpdateModel, DepartmentViewModel>();

        CreateMap<FileTypeViewModel, FileTypeUpdateModel>();
        CreateMap<FileTypeUpdateModel, FileTypeViewModel>();

        CreateMap<FirmViewModel, FirmUpdateModel>();
        CreateMap<FirmUpdateModel, FirmViewModel>();

        CreateMap<MitigationControlViewModel, MitigationControlUpdateModel>();
        CreateMap<MitigationControlUpdateModel, MitigationControlViewModel>();

        CreateMap<ProcessViewModel, ProcessUpdateModel>();
        CreateMap<ProcessUpdateModel, ProcessViewModel>();

        CreateMap<RiskViewModel, RiskUpdateModel>();
        CreateMap<RiskUpdateModel, RiskViewModel>();

        CreateMap<RiskMitigationControlViewModel, RiskMitigationControlUpdateModel>();
        CreateMap<RiskMitigationControlUpdateModel, RiskMitigationControlViewModel>();

        CreateMap<RiskPossibleOptimizationViewModel, RiskPossibleOptimizationUpdateModel>();
        CreateMap<RiskPossibleOptimizationUpdateModel, RiskPossibleOptimizationViewModel>();

        CreateMap<RiskScoreViewModel, RiskScoreUpdateModel>();
        CreateMap<RiskScoreUpdateModel, RiskScoreViewModel>();
    }
}