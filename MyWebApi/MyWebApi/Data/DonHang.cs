namespace MyWebApi.Data
{
    public enum TinhTrangDonDatHang
    {
        New =0,
        Payment = 1,
        Comple =2,
        Cacel = -1
    }
    public class DonHang
    {
        public Guid MaDH { get; set; }
        public DateTime NgDat { get; set; }
        public DateTime? NgGiao { get; set; }
        public TinhTrangDonDatHang TinhTrangDonHang { get; set; }
        public string NguoiNhanHang { get; set; }
        public string SoDienThoai {  get; set; }

        public ICollection<DonHangChiTiet> donHangChiTiets { get; set; }
        public DonHang()
        {
            donHangChiTiets = new List<DonHangChiTiet>();
        }

    }
}
