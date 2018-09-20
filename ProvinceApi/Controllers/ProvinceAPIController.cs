using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvinceApi.Models;

namespace ProvinceApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProvinceAPIController : ControllerBase
    {
        public readonly ProvinceApiContext _context;
        public ProvinceAPIController(ProvinceApiContext context)
        {
            _context = context;
        }

        [HttpGet("{GetAll}")]
        public IEnumerable<Province> GetProvinces()
        {
            return _context.Province;
        }

        [HttpGet("Province/{id}")]
        public async Task<IActionResult> GetProvince(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var province = await _context.Province.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }

            return Ok(province);
        }

        [HttpPatch("Province/{id}", Name = "EditProvince")]
        public async Task<IActionResult> edit(int id, Province _p)
        {
            var p = _context.Province.FirstOrDefault(m => m.Id == id);
            p.Name = _p.Name;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{Province}")]
        public async Task<IActionResult> AddProvinceAsync(Province p)
        {
            await _context.AddAsync(p);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetProvince", new { id = p.Id }, p);
        }
        [HttpDelete("Province/{id}")]
        public async Task<IActionResult> DeleteProvince(int id)
        {
            var p = _context.Province.FirstOrDefault(m => m.Id == id);
            _context.Province.Remove(p);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("Province/{id}")]
        public async Task<IActionResult> UpdateProvince(int id, Province _p)
        {
            var p = _context.Province.FirstOrDefault(m => m.Id == id);
            p.Name = _p.Name;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}