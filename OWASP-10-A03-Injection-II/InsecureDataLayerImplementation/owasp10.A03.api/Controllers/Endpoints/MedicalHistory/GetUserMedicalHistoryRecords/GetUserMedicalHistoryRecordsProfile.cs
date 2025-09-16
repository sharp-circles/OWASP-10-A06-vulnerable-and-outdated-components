using AutoMapper;
using owasp10.A03.api.Controllers.Endpoints.MedicalHistory.GetUserMedicalHistoryRecords.ViewModels;
using owasp10.A03.business.UseCases.GetUserMedicalHistoryRecords.Dtos;

namespace owasp10.A03.api.Controllers.Endpoints.MedicalHistory.GetUserMedicalHistoryRecords;

public class GetUserMedicalHistoryRecordsProfile : Profile
{
    public GetUserMedicalHistoryRecordsProfile()
    {
        CreateMap<GetUserMedicalHistoryRecordsOutput, GetUserMedicalHistoryRecordsViewModel>();
    }
}
