using Asal.StudentManagementSystem.Data;
using Asal.StudentManagementSystem.Interfaces;
using Asal.StudentManagementSystem.Services;
using Asal.StudentManagementSystem.Utilities;

public class Program
{
    public static void Main()
    {
        IStudentRepository repository = new StudentRepository();
        StudentService service = new StudentService(repository);
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("===== Student Management System =====");
            Console.WriteLine("[1] Add Student");
            Console.WriteLine("[2] View All Students");
            Console.WriteLine("[3] Find Student By ID");
            Console.WriteLine("[4] Delete Student");
            Console.WriteLine("[5] Filter Students By Grade");
            Console.WriteLine("[6] Display Average Grade");
            Console.WriteLine("[7] Sort Students By Age");
            Console.WriteLine("[8] Update Student");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("=====================================");

            int choice = StudentManagementSystsemUtilities.AskForNumberBetween(0, 8);

            switch (choice)
            {
                case 1:
                    service.AddStudent();
                    break;

                case 2:
                    service.ViewAllStudents();
                    break;

                case 3:
                    service.GetStudentById();
                    break;

                case 4:
                    service.DeleteStudentById();
                    break;

                case 5:
                    service.FilterStudentsByGrade();
                    break;

                case 6:
                    service.DisplayAverageGrade();
                    break;

                case 7:
                    service.DisplayStudentsSortedByGrade();
                    break;

                case 8:
                    service.UpdateStudent();
                    break;

                case 0:
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
        }


    }

}
