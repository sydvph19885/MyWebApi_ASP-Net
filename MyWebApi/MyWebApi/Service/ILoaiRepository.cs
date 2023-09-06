using MyWebApi.Model;

namespace MyWebApi.Service
{
    public interface ILoaiRepository
    {
        List<LoaiViewModel> GetAll(); 
        LoaiViewModel GetById(int id);
        LoaiViewModel Create(LoaiViewModel model);
        void Update(LoaiViewModel model);
        void Delete(int id);
    }
}
