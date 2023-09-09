namespace MyWebApi.Model
{
    public class HangHoaVM
    {
        public string tenHangHoa {  get; set; }
        public double DonGia {  get; set; }
    }
    public class HangHoa : HangHoaVM
    {
        public Guid MaHangHoa { get; set; }
    }
    public class HangHoaModel
    {
        public Guid MaHangHoa { get; set; }
        public string tenHangHoa { get; set; }
        public double DonGia { get; set; }
        public string TenLoai { get; set; }
    }
}
