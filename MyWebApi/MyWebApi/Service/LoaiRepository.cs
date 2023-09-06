using MyWebApi.Data;
using MyWebApi.Model;

namespace MyWebApi.Service
{
    public class LoaiRepository : ILoaiRepository
    {
        public readonly MyDbContext _context;
        public LoaiRepository(MyDbContext context)
        {
            _context = context;
        }
        public LoaiViewModel Create(LoaiViewModel model)
        {
            var loai = new Loai()
            {
                TenLoai = model.TenLoai,
            };
            _context.Add(loai);
            _context.SaveChanges();
            return model;
        }

        public void Delete(int id)
        {
            var loai = _context.Loais.Where(l => l.MaLoai == id).SingleOrDefault();
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public List<LoaiViewModel> GetAll()
        {
            var loais = _context.Loais.Select(item => new LoaiViewModel
            {
                MaLoai = item.MaLoai,
                TenLoai = item.TenLoai,
            });
            return loais.ToList();
        }

        public LoaiViewModel GetById(int id)
        {
            var loai = _context.Loais.Where(l => l.MaLoai == id).SingleOrDefault();
            if (loai != null)
            {
                return new LoaiViewModel()
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai
                };
            }
            return null;
        }

        public void Update(LoaiViewModel model)
        {
            var loai = _context.Loais.Where(l => l.MaLoai == model.MaLoai).SingleOrDefault();
            loai.TenLoai = model.TenLoai;
            _context.SaveChanges();
        }
    }
}
