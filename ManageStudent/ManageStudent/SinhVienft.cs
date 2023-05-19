using IPersonFactoryNP;
using PersonNP;
using StudentNP;


namespace StudentFactoryNP
{
    public class SinhVienft : IPersonFactory
    {
        public People CreatePerson()
        {

            float grade = 0;

            Console.Write("Nhap MSSV: ");
            string id = Console.ReadLine();

            Console.Write("Nhap ten sinh vien: ");
            string name = Console.ReadLine();

            Console.Write("Nhap SDT sinh vien: ");
            string phone = Console.ReadLine();

            try
            {
                Console.Write("Nhap lop sinh vien: ");
                grade = float.Parse(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("\nNhap sai lop cua sinh vien, vui long nhap lai");
                Console.Write("Nhap lop sinh vien: ");
                grade = float.Parse(Console.ReadLine());
            }

            return new SinhVien(id, name, grade, phone);
        }
    }
}