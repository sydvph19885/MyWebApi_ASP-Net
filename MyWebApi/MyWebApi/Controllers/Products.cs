using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Service;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly IHangHoaReponsitory _hangHoaReponsitory;

        public Products(IHangHoaReponsitory hangHoaReponsitory)
        {
            _hangHoaReponsitory = hangHoaReponsitory;
        }
        [HttpGet]
        public IActionResult GetAllProduct(string search, double? from, double? to, string sortBy)
        {
            try
            {
                var result = _hangHoaReponsitory.GetAll(search,from,to,sortBy);
                return Ok(result);
            }
            catch
            {
                return BadRequest("WE can not product");
            }
        }
    }
}
