using Microsoft.OpenApi.Extensions;
using SampleApiBackend.Models;
using SampleApiBackend.Models.Dtos;
using SampleApiBackend.Repository;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SampleApiBackend.Services
{
    public class SoapService : ISoapService
    {
        private readonly ISoapRepository _soapRepository;

        public SoapService(ISoapRepository _soapRepository)
        {
            this._soapRepository = _soapRepository;
        }

        public async Task<SoapDetailsDto> CreateSoapAsync(CreateSoapDto createSoapDto)
        {
            Soap soap = new Soap
            {
                Name = createSoapDto.Name,
                ScentType = (ScentType)Enum.Parse(typeof(ScentType), createSoapDto.ScentType, true),
                Description = createSoapDto.Description,
                Price = createSoapDto.Price
            };

            await _soapRepository.SaveSoapAsync(soap);

            SoapDetailsDto result = new SoapDetailsDto
            {
                Id = soap.Id,
                Name = createSoapDto.Name,
                ScentType = soap.ScentType.GetDisplayName(),
                Description = createSoapDto.Description,
                Price = createSoapDto.Price
            };

            return result;

        }

        public async Task DeleteSoapAsync(int soapId)
        {
            await _soapRepository.DeleteSoapAsync(soapId);
        }

        public async Task<List<SoapListItemDto>> GetAllSoapsAsync()
        {
            List<Soap> soaps = await _soapRepository.GetAllSoapsAsync();
            List<SoapListItemDto> result = soaps.Select(soap => new SoapListItemDto
            {
                Id = soap.Id,
                Name = soap.Name,
                ScentType = soap.ScentType.GetAttributeOfType<DisplayAttribute>().Name!,
                Description = soap.Description,
                Price = soap.Price,
            }).ToList();

            return result;
        }

        public SoapFormInitDataDto GetFormInitData()
        {
            SoapFormInitDataDto result = new SoapFormInitDataDto
            {
                Scents = Enum.GetValues(typeof(ScentType))
                             .Cast<ScentType>()
                             .Select(scent => new ScentOptionDto
                             {
                                 Name = scent.ToString(),
                                 DisplayName = scent.GetAttributeOfType<DisplayAttribute>().Name!
                             }).ToList(),
            };

            return result;
        }

        public async Task<SoapDetailsDto> GetSoapByIdAsync(int soapId)
        {
            Soap soap = await _soapRepository.GetSoapByIdAsync(soapId);

            SoapDetailsDto result = new SoapDetailsDto
            {
                Id = soap.Id,
                Name = soap.Name,
                ScentType = soap.ScentType.GetAttributeOfType<DisplayAttribute>().Name!,
                Description = soap.Description,
                Price = soap.Price,
            };
            
            return result;
        }
        public async Task<SoapDetailsDto> UpdateSoapById(UpdateSoapDto updateSoapDto)
        {
            Soap originSoap = await _soapRepository.GetSoapByIdAsync(updateSoapDto.Id);

            //Id = updateSoapDto.Id,
            originSoap.Name = updateSoapDto.Name;
            originSoap.ScentType = (ScentType)Enum.Parse(typeof(ScentType), updateSoapDto.ScentType, true);
            originSoap.Description = updateSoapDto.Description;

            await _soapRepository.UpdateSoapAsync(originSoap);

            SoapDetailsDto result = new SoapDetailsDto
            {
                Id = originSoap.Id,
                Name = originSoap.Name,
                ScentType = originSoap.ScentType.GetDisplayName(),
                Description = originSoap.Description,
                Price = originSoap.Price
            };

            return result;
        }
    }
}
