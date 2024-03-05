using Microsoft.EntityFrameworkCore;
using SampleApiBackend.Database;
using SampleApiBackend.Models;

namespace SampleApiBackend.Repository
{
    public class SoapRepository : ISoapRepository
    {
        private readonly SoapDbContext _soapDbContext;

        public SoapRepository(SoapDbContext soapDbContext)
        {
            _soapDbContext = soapDbContext;
        }

        public async Task DeleteSoapAsync(int soapId)
        {
            Soap soap = await GetSoapByIdAsync(soapId);
            _soapDbContext.Soaps.Remove(soap);
            await _soapDbContext.SaveChangesAsync();
        }

        public async Task<List<Soap>> GetAllSoapsAsync()
        {
            return await _soapDbContext.Soaps.ToListAsync();
        }

        public async Task<Soap> GetSoapByIdAsync(int soapId)
        {
            //thrown an exception if not find a soap with soapId.
            return await _soapDbContext.Soaps.Where(soap => soap.Id == soapId).FirstOrDefaultAsync() ?? throw new ArgumentException($"No soap with this id: {soapId}");
        }

        public async Task SaveSoapAsync(Soap soap)
        {
            //add to database
            await _soapDbContext.Soaps.AddAsync(soap);
            //save database
            await _soapDbContext.SaveChangesAsync();
        }

        public async Task UpdateSoapAsync(Soap updatedSoap)
        {
            _soapDbContext.Soaps.Update(updatedSoap);
            await _soapDbContext.SaveChangesAsync();
        }
    }
}
