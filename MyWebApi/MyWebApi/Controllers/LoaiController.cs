using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Data;
using MyWebApi.Model;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _contex;
        public LoaiController(MyDbContext contex)
        {
            _contex = contex;
        }
        [HttpGet]
        public IActionResult GetALL()
        {
            List<Loai> loais = _contex.Loais.ToList();
            return Ok(loais);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ds = _contex.Loais.Where(x => x.MaLoai == id).SingleOrDefault();
            if (ds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ds);
            }
        }
        [HttpPost]
        public IActionResult Post(LoaiModel model)
        {
            try
            {
                var loai = new Loai()
                {
                    TenLoai = model.TenLoai,
                };
                _contex.Add(loai);
                _contex.SaveChanges();
                //return Ok("Add thanh cong");
                return StatusCode(StatusCodes.Status201Created, model); ;

            }
            catch
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, LoaiModel model)
        {
            var loai = _contex.Loais.Where(x => x.MaLoai == id).SingleOrDefault();
            if(loai == null)
            {
                return NotFound();
            }
            else
            {
                loai.TenLoai = model.TenLoai;
                _contex.SaveChanges();
                return Ok(loai);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Loai loai = _contex.Loais.Where(x => x.MaLoai == id).SingleOrDefault();
            if(loai == null)
            {
                return NotFound();
            }
            else
            {
                _contex.Remove(loai);
                _contex.SaveChanges();
                return Ok("Xoa thanh con");
            }
        }
    }
}
