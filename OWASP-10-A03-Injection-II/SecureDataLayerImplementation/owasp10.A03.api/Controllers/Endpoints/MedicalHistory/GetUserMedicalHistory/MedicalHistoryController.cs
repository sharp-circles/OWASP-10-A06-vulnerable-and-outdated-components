using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using owasp10.A03.api.Controllers.Endpoints.MedicalHistory.GetUserMedicalHistory.ViewModels;
using owasp10.A03.business.UseCases.GetUserMedicalHistory.Contracts;
using owasp10.A03.business.UseCases.GetUserMedicalHistory.Dtos;

namespace owasp10.A03.api.Controllers.Endpoints.MedicalHistory.GetUserMedicalHistory;

[ApiController]
[Route("[controller]")]
public class MedicalHistoryController : ControllerBase
{
    private readonly IGetUserMedicalHistoryInteractor _businessInteractor;
    private readonly IMapper _mapper;

    public MedicalHistoryController(IGetUserMedicalHistoryInteractor businessInteractor, IMapper mapper)
    {
        _businessInteractor = businessInteractor;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserMedicalHistory(int id)
    {
        var userMedicalHistoryInteractorInput = new GetUserMedicalHistoryInput() { Id = id };

        var userMedicalHistoryInteractorOutput = await _businessInteractor.Handle(userMedicalHistoryInteractorInput);

        var userMedicalHistoryViewModel = _mapper.Map<GetUserMedicalHistoryViewModel>(userMedicalHistoryInteractorOutput);

        return new OkObjectResult(userMedicalHistoryViewModel);
    }
}

