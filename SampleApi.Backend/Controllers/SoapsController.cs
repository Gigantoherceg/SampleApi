using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SampleApiBackend.Database;
using SampleApiBackend.Models;
using SampleApiBackend.Models.Dtos;
using SampleApiBackend.Services;

namespace SampleApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoapsController : ControllerBase
    {
        private readonly ISoapService _soapService;


        public SoapsController(ISoapService soapService)
        {
            _soapService = soapService;
        }

        [HttpPost]
        public async Task<ActionResult<SoapDetailsDto>> CreateSoapAsync(CreateSoapDto createSoapDto)
        {
            SoapDetailsDto result = await _soapService.CreateSoapAsync(createSoapDto);
            return CreatedAtAction(nameof(GetSoapAsync), new { id = result.Id }, result);
        }

        [HttpGet("{soapId}")]
        public async Task<ActionResult<SoapDetailsDto>> GetSoapByIdAsync(int soapId)
        {
            SoapDetailsDto result = await _soapService.GetSoapByIdAsync(soapId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<SoapDetailsDto>> GetSoapAsync()
        {
            return await Task.FromResult(new SoapDetailsDto());
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<SoapListItemDto>>> GetAllSoapsAsync()
        {
            List<SoapListItemDto> result = await _soapService.GetAllSoapsAsync();
            return Ok(result);
        }

        [HttpDelete("{soapId}")]
        public async Task<ActionResult> DeleteSoapAsync(int soapId)
        {
            await _soapService.DeleteSoapAsync(soapId);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<SoapDetailsDto>> UpdateSoapByIdAsync(UpdateSoapDto updateSoapDto)
        {
            SoapDetailsDto result = await _soapService.UpdateSoapById(updateSoapDto);
            return Ok(result);
        }

    }
}
