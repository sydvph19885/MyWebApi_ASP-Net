using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;
using MyWebApi.Service;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaissController : ControllerBase
    {
        private readonly ILoaiRepository loaiRepository;
        public LoaissController(ILoaiRepository loaiRepository)
        {
            this.loaiRepository = loaiRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(loaiRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = loaiRepository.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, LoaiViewModel loaiView)
        {
            loaiRepository.Update(loaiView);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           loaiRepository.Delete(id);
            return NoContent();
        }
        [HttpPost]
        public IActionResult Add(LoaiViewModel loaiView)
        {
            loaiRepository.Create(loaiView);
            return NoContent();
        }
    }
}
