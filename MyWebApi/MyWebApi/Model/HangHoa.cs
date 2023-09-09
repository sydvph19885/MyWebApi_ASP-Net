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
<<<<<<< HEAD
    public class HangHoaModel
    {
        public Guid MaHangHoa { get; set; }
        public string tenHangHoa { get; set; }
        public double DonGia { get; set; }
        public string TenLoai { get; set; }
    }
=======
>>>>>>> 505a09b04007c96d6719b83993edc1136cc8b4e9
}
