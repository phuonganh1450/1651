using IPersonFactoryNP;
using PersonNP;
using TeacherNP;

namespace TeacherFactoryNP
{
    public class Teacherft : IPersonFactory
    {
        public People CreatePerson()
        {

            Console.Write("Nhap ID giao vien: ");
            string id = Console.ReadLine();

            Console.Write("Nhap ten giao vien: ");
            string name = Console.ReadLine();

            Console.Write("Nhap mon hoc: ");
            string teachingSubject = Console.ReadLine();

            return new Teacher(id, name, teachingSubject);
        }
    }
}