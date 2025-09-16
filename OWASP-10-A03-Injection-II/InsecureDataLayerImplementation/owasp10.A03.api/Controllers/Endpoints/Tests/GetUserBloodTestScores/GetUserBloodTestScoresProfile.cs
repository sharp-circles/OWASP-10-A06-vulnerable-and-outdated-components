using AutoMapper;
using owasp10.A03.api.Controllers.Endpoints.Tests.GetUserBloodTestScores.ViewModels;
using owasp10.A03.business.UseCases.Tests.GetUserBloodTestScores.Dtos;

namespace owasp10.A03.api.Controllers.Endpoints.Tests.GetUserBloodTestScores;

public class GetUserBloodTestScoresProfile : Profile
{
    public GetUserBloodTestScoresProfile()
    {
        CreateMap<GetUserBloodTestScoresOutput, GetUserBloodTestScoresViewModel>();
    }
}
