using AutoMapper;
using owasp10.A03.api.Controllers.Endpoints.MedicalHistory.GetUserMedicalHistory.ViewModels;
using owasp10.A03.business.UseCases.GetUserMedicalHistory.Dtos;

namespace owasp10.A03.api.Controllers.Endpoints.MedicalHistory.GetUserMedicalHistory;

public class GetUserMedicalHistoryProfile : Profile
{
    public GetUserMedicalHistoryProfile()
    {
        CreateMap<GetUserMedicalHistoryOutput, GetUserMedicalHistoryViewModel>();
    }
}
