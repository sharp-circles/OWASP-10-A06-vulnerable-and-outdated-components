using AutoMapper;
using owasp10.A03.business.Data;
using owasp10.A03.business.UseCases.GetUserMedicalHistory.Contracts;
using owasp10.A03.business.UseCases.GetUserMedicalHistory.Dtos;

namespace owasp10.A03.business.UseCases.GetUserMedicalHistory;

public sealed class GetUserMedicalHistoryInteractor : IGetUserMedicalHistoryInteractor
{
    private readonly ISqLiteRepository<Entities.MedicalHistory> _medicalHistoryRepository;
    private readonly IMapper _mapper;

    public GetUserMedicalHistoryInteractor(ISqLiteRepository<Entities.MedicalHistory> medicalHistoryRepository, IMapper mapper)
    {
        _medicalHistoryRepository = medicalHistoryRepository;
        _mapper = mapper;
    }

    public async Task<GetUserMedicalHistoryOutput> Handle(GetUserMedicalHistoryInput getUserMedicalHistoryInput)
    {
        var userMedicalHistory = await _medicalHistoryRepository.GetAsync(getUserMedicalHistoryInput.Id);

        var userMedicalHistoryOutput = _mapper.Map<GetUserMedicalHistoryOutput>(userMedicalHistory);

        return userMedicalHistoryOutput;
    }
}
