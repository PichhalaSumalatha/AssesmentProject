
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecords
{

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Teacher> teachers = TeacherDataProcessor.LoadTeacherData();

            while (true)
            {
                Console.WriteLine("Welcome to Rainbow School Teacher Data System");
                Console.WriteLine("1. View All Teachers");
                Console.WriteLine("2. Add New Teacher");
                Console.WriteLine("3. Update Teacher Data");
                Console.WriteLine("4. Exit");

                Console.WriteLine("Enter your Choice");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ViewAllTeachers(teachers);
                        break;
                    case 2:
                        AddNewTeacher(teachers);
                        break;
                    case 3:
                        UpdateTeacherData(teachers);
                        break;
                    case 4:
                        TeacherDataProcessor.SaveTeacherData(teachers);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.Write("Do you want to continue (yes/no)?:");
                string continueChoice = Console.ReadLine();
                if (continueChoice.ToLower() != "yes")
                {
                    break;
                }
            }
        }

        static void ViewAllTeachers(List<Teacher> teachers)
        {
            Console.WriteLine("\nAll Teachers:");
            foreach (Teacher teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}, Class: {teacher.Class}, Section: {teacher.Section}");
            }
        }

        static void AddNewTeacher(List<Teacher> teachers)
        {
            Console.Write("\nEnter Teacher ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Teacher Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class: ");
            string teacherClass = Console.ReadLine();

            Console.Write("Enter Section: ");
            string section = Console.ReadLine();

            teachers.Add(new Teacher
            {
                ID = id,
                Name = name,
                Class = teacherClass,
                Section = section
            });

            Console.WriteLine("Teacher data added successfully!");
        }

        static void UpdateTeacherData(List<Teacher> teachers)
        {
            Console.Write("\nEnter Teacher ID to update: ");
            int idToUpdate = int.Parse(Console.ReadLine());

            Teacher teacherToUpdate = teachers.Find(t => t.ID == idToUpdate);
            if (teacherToUpdate == null)
            {
                Console.WriteLine("Teacher with specified ID not found.");
                return;
            }

            Console.Write("Enter updated Teacher Name: ");
            teacherToUpdate.Name = Console.ReadLine();

            Console.Write("Enter updated Class: ");
            teacherToUpdate.Class = Console.ReadLine();

            Console.Write("Enter updated Section: ");
            teacherToUpdate.Section = Console.ReadLine();

            Console.WriteLine("Teacher data updated successfully!");
        }
    }
}



