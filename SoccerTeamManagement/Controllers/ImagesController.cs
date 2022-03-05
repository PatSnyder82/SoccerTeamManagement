using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerTeamManagement.Data;
using SoccerTeamManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImagesController(ApplicationDbContext context, IWebHostEnvironment webHostingEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostingEnvironment;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImage()
        {
            return await _context.Image.ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
            var image = await _context.Image.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage(int id, Image image)
        {
            if (id != image.Id)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostImage(IFormFile file, [ModelBinder(BinderType = typeof(JsonModelBinder))] Image image)
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);

            try
            {
                if (file == null || file?.Length < 1 || String.IsNullOrWhiteSpace(file?.FileName))
                    return BadRequest();

                var url = GetUrl(file.FileName);

                using (var stream = new FileStream(url, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                };

                image.Url = url;

                var entity = _context.Image.Add(image);
                await _context.SaveChangesAsync();
                var id = entity.CurrentValues["Id"];
                return Ok(id);
                //return CreatedAtAction("PostImage", entity);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var image = await _context.Image.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Image.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageExists(int id)
        {
            return _context.Image.Any(e => e.Id == id);
        }

        private string GetUrl(string fullFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(fullFileName);
            var fileExtension = Path.GetExtension(fullFileName);
            var timeStamp = $"({DateTime.Now:yyyy-MM-dd_hh-mm-ss-fff})";

            var newFileName = string.Concat(fileName, timeStamp, fileExtension);

            return Path.Combine(_webHostEnvironment.ContentRootPath, ("UploadedFiles"), newFileName);
        }
    }
}