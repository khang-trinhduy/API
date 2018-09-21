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
        /// <summary>
        /// Get all provinces.
        /// </summary>
        [HttpGet]
        public IEnumerable<Province> GetProvinces()
        {
            return _context.Province;
        }

        /// <summary>
        /// Get a specific province.
        /// </summary>
        /// <param name="id">Index of province to show.</param> 
        /// <returns>Province with the same id</returns>
        /// <response code="404">A province with id was not found</response>
        /// <response code="200">Success</response>
        [HttpGet("Province/{id}",Name = "GetProvince")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
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

        /// <summary>
        /// Edit a province.
        /// This method doesn't work, use the Put one to edit.
        /// </summary>
        /// <param name="id">Index of province to edit.</param> 
        /// <param name="_p">Province after edit.</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /ProvinceAPI/Province/id
        ///     {
        ///        "name": "Hà Nội",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Edit successful</response>
        /// <response code="400">Failed to edit province at index id</response>
        [HttpPatch("Province/{id}", Name = "EditProvince")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> edit(int id, Province _p)
        {
            var p = _context.Province.FirstOrDefault(m => m.Id == id);
            p.Name = _p.Name;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Add a specific province.
        /// </summary>
        /// <param name="p">Province to add.</param> 
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /ProvinceAPI/Province
        ///     {
        ///        "name": "Hà Nội",
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created Province</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost("{Province}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddProvinceAsync(Province p)
        {
            await _context.AddAsync(p);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetProvince", new { id = p.Id }, p);
        }

        /// <summary>
        /// Deletes a specific province.
        /// </summary>
        /// <param name="id">Index of province to remove.</param>  
        /// <response code="200">Success</response>
        /// <response code="500">Unexpected error</response>
        [HttpDelete("Province/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteProvince(int id)
        {
            var p = _context.Province.FirstOrDefault(m => m.Id == id);
            _context.Province.Remove(p);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Edit a province.
        /// </summary>
        /// <param name="id">Index of province to edit.</param>  
        /// <param name="_p">Province after edit.</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /ProvinceAPI/Province/id
        ///     {
        ///        "name": "Hà Nội",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="500">Unexpected error</response>
        [HttpPut("Province/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateProvince(int id, Province _p)
        {
            var p = _context.Province.FirstOrDefault(m => m.Id == id);
            p.Name = _p.Name;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}