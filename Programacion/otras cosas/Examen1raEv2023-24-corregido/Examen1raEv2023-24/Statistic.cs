using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Examen1raEv2023_24
{
    public class Statistic
    {
        public class NoteStadistics
        {
            public int MajorThan9;
            public int MajotThan7;
            public int MajorThan5;
            public int MajorThan3;
            public int MajorThan0;
        }

        private List<Student> classroom = new List<Student>();

        public static double GetAverageIMC(Classroom classroom)
        {
            if (classroom == null)
                return 0.0;

            double result = 0.0;

            for (int i = 0; i < classroom.GetStudentCount(); i++)
            {
                Student? student = classroom.GetStudentAt(i);
                result += student.GetIMC();
            }
            return result / classroom.GetStudentCount();
        }

        public static Student? GetBestStudent(Classroom classroom)
        {
            if (classroom == null || classroom.GetStudentCount() == 0)
                return null;

            Student? best = classroom.GetStudentAt(0);
            for (int i = 1; i < classroom.GetStudentCount(); i++)
            {
                Student? student = classroom.GetStudentAt(i);
                if (student.GetBestQualification() > best.GetBestQualification())
                {
                    best = student;
                }
            }
            return best;
        }

        public static Student? GetYoungestStudent(Classroom classroom)
        {
            if (classroom == null || classroom.GetStudentCount() == 0)
                return null;

            Student? young = classroom.GetStudentAt(0);
            for (int i = 1; i < classroom.GetStudentCount(); i++)
            {
                Student? student = classroom.GetStudentAt(i);
                if (student.GetAge() > young.GetAge())
                {
                    young = student;
                }
            }
            return young;
        }

        public static List<Student> GetAllStudents(Classroom classroom)
        {
            if (classroom == null)
                return null;

            List<Student> students = new List<Student>();

            for (int i = 1; i < classroom.GetStudentCount(); i++)
            {
                students.Add(classroom.GetStudentAt(i));
            }
            return students;
        }

        public static List<Student> GetSortedStudentsForSignature(Classroom classroom, Signatures signatures)
        {
            List<Student> students = GetAllStudents(classroom);
            SortStudentBySignature(students, signatures);
            return students;
        }

        public static void SortStudentBySignature(List<Student> students, Signatures signature)
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    double qualification_i = students[i].GetNotes().GetQualificationForSignature(signature);
                    double qualification_j = students[j].GetNotes().GetQualificationForSignature(signature);

                    if (qualification_j > qualification_i)
                    {
                        Student aux = students[i];
                        students[i] = students[j];
                        students[j] = aux;

                    }
                }
            }
        }

        public static List<Student> GetAllStudents(Classroom classroom, GenderType gender)
        {
            if (classroom == null)
                return null;

            List<Student> students = new List<Student>();

            for (int i = 1; i < classroom.GetStudentCount(); i++)
            {
                Student? student = classroom.GetStudentAt(i);
                if (student.GetGenderType() == gender)
                    students.Add(classroom.GetStudentAt(i));
            }
            return students;
        }

        public static List<Student> GetStudentWithGender(Classroom classroom, GenderType gender)
        {
            if (classroom == null)
                return null;

            List<Student> students = GetAllStudents(classroom, gender);
            SortStudentByAge(students);
            return students;
        }

        public static void SortStudentByAge(List<Student> students)
        {
            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    int age_i = students[i].GetAge();
                    int age_j = students[j].GetAge();

                    if (age_j > age_i)
                    {
                        Student aux = students[i];
                        students[i] = students[j];
                        students[j] = aux;

                    }
                }
            }
        }

        //en este caso se hace una clase nueva, llamada NoteStadistic, para quien la llame devuelva
        //los alumnos con las notas
        public static NoteStadistics GetStadistics(Classroom classroom)
        {
            NoteStadistics result = new NoteStadistics();

            for(int i = 0; i < classroom.GetStudentCount(); i++)
            {
                Student? student = classroom.GetStudentAt(i);
                double qualification = student.GetNotes().GetAverage();
                if (qualification >= 9)
                    result.MajorThan9++;
                else if (qualification >= 7)
                    result.MajotThan7++;
                else if (qualification >= 5)
                    result.MajorThan5++;
                else if (qualification >= 3)
                    result.MajorThan3++;
                else result.MajorThan0++;
            }
            return result;


        }
    }
}


