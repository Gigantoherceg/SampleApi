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

        //private readonly SampleDbContext _context;

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

        [HttpGet("formData")]
        public ActionResult<SoapFormInitDataDto> GetFormInitData()
        {
            return Ok(_soapService.GetFormInitData());
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

        //// GET: api/Soaps
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Soap>>> GetSoaps()
        //{
        //  if (_context.Soaps == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Soaps.ToListAsync();
        //}

        //// GET: api/Soaps/5
        //[HttpGet(nameof(GetSoap))]
        //public async Task<ActionResult<Soap>> GetSoap(int id)
        //{
        //  if (_context.Soaps == null)
        //  {
        //      return NotFound();
        //  }
        //    var soap = await _context.Soaps.FindAsync(id);

        //    if (soap == null)
        //    {
        //        return NotFound();
        //    }

        //    return soap;
        //}

        //// PUT: api/Soaps/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut(nameof(PutSoapAsync))]
        //public async Task<IActionResult> PutSoapAsync(int id, Soap soap)
        //{
        //    if (id != soap.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(soap).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SoapExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Soaps
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Soap>> PostSoap(Soap soap)
        //{
        //  if (_context.Soaps == null)
        //  {
        //      return Problem("Entity set 'SampleDbContext.Soaps'  is null.");
        //  }
        //    _context.Soaps.Add(soap);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSoap", new { id = soap.Id }, soap);
        //}

        //// DELETE: api/Soaps/5
        //[HttpDelete(nameof(DeleteSoap))]
        //public async Task<IActionResult> DeleteSoap(int id)
        //{
        //    if (_context.Soaps == null)
        //    {
        //        return NotFound();
        //    }
        //    var soap = await _context.Soaps.FindAsync(id);
        //    if (soap == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Soaps.Remove(soap);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool SoapExists(int id)
        //{
        //    return (_context.Soaps?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
