using MyWebApi.Data;
using MyWebApi.Model;

namespace MyWebApi.Service
{
    public class HangHoaReponsitory : IHangHoaReponsitory
    {
        private readonly MyDbContext _context;
        public HangHoaReponsitory(MyDbContext context)
        {
            _context = context;
        }
        public List<HangHoaModel> GetAll(string search, double? from, double? to, string? sortBy)
        {
            //var allProducts = _context.HangHoas.AsQueryable();
            //if (!string.IsNullOrEmpty(search))
            //{
            //    allProducts =  allProducts.Where(sp => sp.TenHH.Contains(search));
            //}
            var allProducts = _context.HangHoas.Where(sp => sp.TenHH.Contains(search));
            #region Fillter
            if (from.HasValue)
            {
                allProducts.Where(hh => hh.DonGia >= from);
            }
            if (to.HasValue)
            {
                allProducts.Where(hh => hh.DonGia <= to);
            }
            #endregion
            #region Sort
            //default sort by name(TenHh)
            allProducts = allProducts.OrderBy(hh => hh.TenHH);
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "tenhh_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.TenHH);
                        break;
                    case "gia_asc":
                        allProducts = allProducts.OrderBy(hh => hh.DonGia);
                        break;
                    case "gia_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.DonGia);
                        break;
                }
            }

            #endregion
            var result = allProducts.Select(sp => new HangHoaModel
            {
                MaHangHoa = sp.MaHH,
                tenHangHoa = sp.TenHH,
                DonGia = sp.DonGia,
                TenLoai = sp.Loai.TenLoai
            });
            return result.ToList();

        }
    }
}