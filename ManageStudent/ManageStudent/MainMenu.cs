using IPersonFactoryNP;
using PersonIteratorNP;
using PersonManageNP;
using PersonNP;
using StudentFactoryNP;
using StudentNP;
using TeacherFactoryNP;
using TeacherNP;

internal class MainMenu
{
    static void Main(string[] args)
    {
        Peoplemanagement manager = new Peoplemanagement();

        while (true)
        {
            Console.WriteLine("\n ======== PHAN MEM QUAN LY HOC SINH ========");
            Console.WriteLine("1. Hien thi thong tin lop hoc: ");
            Console.WriteLine("2. Them thong tin");
            Console.WriteLine("3. Chinh sua thong tin");
            Console.WriteLine("4. Xoa thong tin");
            Console.WriteLine("5. Thoat khoi ung dung!");
            Console.WriteLine("\n ======== ------------------------- ========");

            Console.Write("\n Nhap lua chon cua ban: ");

            int option = 0;

            try
            {
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:

                        IIterator iterator = manager.CreateIterator();

                        if (iterator.HasNext())
                        {
                            Console.WriteLine("\nDANH SACH SINH VIEN: ");
                            Console.WriteLine(
                                "{0,-10} {1,-20} {2,-30} {3,-30} {4,-20}", "    ", "MSSV", "Ten", "Lop / Giao vien ", "SDT");
                            Console.WriteLine("Hoan thanh yeu cau!");

                            while (iterator.HasNext())
                            {
                                People person = iterator.Next();

                                Console.WriteLine("{0,-10} {1,-20} {2,-30} {3,-30} {4,-20}",
                                    person is Teacher ? "Giao vien:" : "Sinh vien:", person.Id, person.Name,
                                    person is Teacher ? ((Teacher)person).TeachingSubject : ((SinhVien)person).Grade,
                                    person is Teacher ? "       " : ((SinhVien)person).Phone);

                            }
                        }
                        else
                        {
                            Console.WriteLine("\nDanh sach trong!");
                        }

                        break;
                    case 2:
                        {
                            Console.WriteLine("Vui long nhap thong tin:");
                            Console.Write("Chon doi tuong 1:Giao vien hoac 2: Sinh vien ");

                            int choice = int.Parse(Console.ReadLine());

                            if (choice == 2)
                            {
                                IPersonFactory studentFactory = new SinhVienft();
                                People student = studentFactory.CreatePerson();
                                manager.AddPerson(student);
                                Console.WriteLine("\nThong tin sinh vien da duoc them vao!");
                            }
                            else
                            {
                                IPersonFactory teacherFactory = new Teacherft();
                                People teacher = teacherFactory.CreatePerson();
                                manager.AddPerson(teacher);
                                Console.WriteLine("\nThong tin giao vien da duoc them vao!");
                            }

                        }

                        break;

                    case 3:
                        Console.WriteLine("\nVui long nhap thong tin can chinh sua");
                        Console.Write("Nhap MSSV: ");
                        string idUpdate = Console.ReadLine();
                        manager.Update(idUpdate);
                        break;
                    case 4:
                        Console.Write("Nhap MSSV can xoa: ");
                        string idDelete = Console.ReadLine();
                        manager.DeletepersonById(idDelete);
                        break;
                    case 5:
                        Console.WriteLine("Bye bye hen gap lai! ");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\n LOI!! VUI LONG NHAP LAI");
                        break;
                }


            }
            catch (FormatException)
            {
                Console.WriteLine("\n KHONG CO YEU CAU NAY, VUI LONG NHAP LAI: ");
            }

        }
    }
}
