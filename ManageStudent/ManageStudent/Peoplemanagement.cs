using PersonIteratorNP;
using PersonNP;
using StudentNP;
using TeacherNP;

namespace PersonManageNP
{
    public interface IPersonManage
    {
        IIterator CreateIterator();
    }

    public class Peoplemanagement : IPersonManage
    {
        private List<People> _persons = new List<People>();

        public void AddPerson(People Person)
        {
            _persons.Add(Person);
        }

        public IIterator CreateIterator()
        {
            return new PersonIterator(_persons);
        }

        public void DeletepersonById(string id)
        {
            // Browse through the person list
            for (int i = 0; i < _persons.Count; i++)
            {
                if (_persons[i].Id == id)
                {
                    _persons.RemoveAt(i);
                    Console.WriteLine("Xoa nguoi dung co MSSV = {0}", id);
                    return;
                }
            }
            Console.WriteLine("Khong tim thay nguoi dung co MSSV = {0}", id);
        }

        // person update function
        public void Update(string id)
        {
            // Find the person with the given id
            People personToUpdate = null;

            foreach (People person in _persons)
            {
                if (person.Id == id)
                {
                    personToUpdate = person;
                    break;
                }
            }

            if (personToUpdate == null)
            {
                Console.WriteLine($"Khong tim thay MSSV = {id}");
                return;
            }

            // Update the person based on its type
            if (personToUpdate is Teacher)
            {
                Teacher teacherToUpdate = (Teacher)personToUpdate;

                try
                {
                    // Prompt the user to enter the new Teacher information
                    Console.Write("Nhap ID cua giao vien: ");
                    string idT = Console.ReadLine();

                    Console.Write("Nhap ten giao vien: ");
                    string name = Console.ReadLine();

                    Console.Write("Giao vien tren se phu trach mon hoc: ");
                    string teachingSubject = Console.ReadLine();
                    // Update the Teacher object with the new information
                    teacherToUpdate.Id = idT;
                    teacherToUpdate.Name = name;
                    teacherToUpdate.TeachingSubject = teachingSubject;


                    Console.WriteLine("Thong tin giao vien da duoc cap nhat!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nSai thong tin, vui long nhap lai: ");
                }

            }
            else if (personToUpdate is SinhVien)
            {
                // Cast the person to a Toy object
                SinhVien studentToUpdate = (SinhVien)personToUpdate;

                try
                {
                    Console.Write("Nhap MSSV: ");
                    string idS = Console.ReadLine();

                    Console.Write("Nhap ten Sinh vien ");
                    string name = Console.ReadLine();

                    Console.Write("Nhap lop: ");
                    float grade = float.Parse(Console.ReadLine());

                    Console.Write("SĐT: ");
                    string phone = Console.ReadLine();

                    // Update the toy object with the new information
                    studentToUpdate.Id = idS;
                    studentToUpdate.Name = name;
                    studentToUpdate.Grade = grade;
                    studentToUpdate.Phone = phone;

                    Console.WriteLine("Thong tin sinh vien da duoc cap nhat");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nSai thong tin, vui long nhap lai!");
                }

            }

        }

    }

}