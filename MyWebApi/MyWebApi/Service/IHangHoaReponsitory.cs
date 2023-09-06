using MyWebApi.Model;

namespace MyWebApi.Service
{
    public interface IHangHoaReponsitory
    {
        List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy);
    }
}
