using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TeacherRecords;

namespace TeacherRecords
{
    internal class TeacherDataProcessor
    {
        private const string FilePath = @"D:\Phase end Assesment\Project-2\TeacherRecords\TeacherRecords\Teacher.txt";
        public static void SaveTeacherData(List<Teacher> teachers)
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (Teacher teacher in teachers)
                {
                    writer.WriteLine($"{teacher.ID},{teacher.Name},{teacher.Class},{teacher.Section}");
                }
            }
        }

        public static List<Teacher> LoadTeacherData()
        {
            List<Teacher> teachers = new List<Teacher>();

            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            int id = int.Parse(parts[0]);
                            string name = parts[1];
                            string teacherClass = parts[2];
                            string section = parts[3];

                            teachers.Add(new Teacher
                            {
                                ID = id,
                                Name = name,
                                Class = teacherClass,
                                Section = section
                            });
                        }
                    }
                }
            }

            return teachers;
        }

    }
}
