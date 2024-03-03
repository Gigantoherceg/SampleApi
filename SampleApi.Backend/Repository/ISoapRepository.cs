using SampleApiBackend.Models;

namespace SampleApiBackend.Repository
{
    public interface ISoapRepository
    {
        Task DeleteSoapAsync(int soapId);
        Task<List<Soap>> GetAllSoapsAsync();
        Task<Soap> GetSoapByIdAsync(int soapId);
        Task SaveSoapAsync(Soap soap);
        Task UpdateSoapAsync(Soap result);
    }
}