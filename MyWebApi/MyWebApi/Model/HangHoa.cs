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
}
