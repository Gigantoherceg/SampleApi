﻿using Microsoft.OpenApi.Extensions;
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
            //create new soap
            Soap soap = new Soap
            {
                Name = createSoapDto.Name,
                Description = createSoapDto.Description,
                Price = createSoapDto.Price
            };

            //preparation for save
            await _soapRepository.SaveSoapAsync(soap);

            //returning the new soap
            SoapDetailsDto result = new SoapDetailsDto
            {
                Id = soap.Id,
                Name = createSoapDto.Name,
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
            //get all soaps to list from database
            List<Soap> soaps = await _soapRepository.GetAllSoapsAsync();

            //
            List<SoapListItemDto> result = soaps.Select(soap => new SoapListItemDto
            {
                Id = soap.Id,
                Name = soap.Name,
                Description = soap.Description,
                Price = soap.Price,
            }).ToList();

            return result;
        }

        public async Task<SoapDetailsDto> GetSoapByIdAsync(int soapId)
        {
            Soap soap = await _soapRepository.GetSoapByIdAsync(soapId);

            SoapDetailsDto result = new SoapDetailsDto
            {
                Id = soap.Id,
                Name = soap.Name,
                Description = soap.Description,
                Price = soap.Price,
            };
            
            return result;
        }
        public async Task<SoapDetailsDto> UpdateSoapById(UpdateSoapDto updateSoapDto)
        {
            //search for the soap you want to change
            Soap originSoap = await _soapRepository.GetSoapByIdAsync(updateSoapDto.Id);


            //update fields
            originSoap.Name = updateSoapDto.Name;
            originSoap.Description = updateSoapDto.Description;
            originSoap.Price = updateSoapDto.Price;

            //send save to database
            await _soapRepository.UpdateSoapAsync(originSoap);

            //returning the updated soap
            SoapDetailsDto result = new SoapDetailsDto
            {
                Id = originSoap.Id,
                Name = originSoap.Name,
                Description = originSoap.Description,
                Price = originSoap.Price
            };

            return result;
        }
    }
}
