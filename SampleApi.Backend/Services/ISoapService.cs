using SampleApiBackend.Models.Dtos;

namespace SampleApiBackend.Services
{
    public interface ISoapService
    {
        Task<SoapDetailsDto> CreateSoapAsync(CreateSoapDto createSoapDto);
        Task DeleteSoapAsync(int soapId);
        Task<List<SoapListItemDto>> GetAllSoapsAsync();
        SoapFormInitDataDto GetFormInitData();
        Task<SoapDetailsDto> GetSoapByIdAsync(int soapId);
        Task<SoapDetailsDto> UpdateSoapById(UpdateSoapDto updateSoapDto);
    }
}