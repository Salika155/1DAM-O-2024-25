using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNov2023
{
    public static class Statistic
    {
        public static double GetAverageIMC(Classroom cl)
        {
            if (cl == null)
                return 0.0;

            double result = 0.0;

            for(int i = 0; i < cl.GetStudentCount(); i++) 
            {
                Student? s = cl.GetStudentAt(i);
                result += s.GetIMC();
            }
            return result / cl.GetStudentCount();
        }

        public static Student? GetBestStudent(Classroom cl) 
        {
            if (cl == null || cl.GetStudentCount() == 0) 
                return null;
            Student? best = cl.GetStudentAt(0);
            for(int i = 1; i < cl.GetStudentCount(); i++)
            {
                Student? st = cl.GetStudentAt(i);
                if (st.GetBestQualification() > best.GetBestQualification())
                    best = st;
            }
            return best;
        }

        public static Student? GetYoungerStudent(Classroom cl)
        {
            if (cl == null || cl.GetStudentCount() == 0)
                return null;
            Student? best = cl.GetStudentAt(0);
            for(int i = 0; i < cl.GetStudentCount(); i++)
            {
                //Student? s = cl.GetStudentAt(i);
                //if (s.GetYoungStudent() > best.GetYoungStudent())
                //best = s;
            }
            return best;
        }
        public static List<Student> GetAllStudents(Classroom cl)
        {
            List<Student> students = new List<Student>();
            for(int i = 0; i < cl.GetStudentCount(); i++)
            {
                students.Add(cl.GetStudentAt(i));
            }
            return students;
        }

        public static List<Student> GetSortedStudentsForSignatures(Classroom cl, SignatureType signature)
        {
            List<Student> students = GetAllStudents(cl);
            SortStudentBySignature(students, signature);



            return students;
        }

        public static void SortStudentBySignature(List<Student> students, SignatureType signature)
        {
            for(int i = 0; i < students.Count - 1; i++) 
            {
                for (int j = i + 1; j < students.Count; j++)
                {
                    double qualif_i = students[i].GetQualification().GetQualificationForSignature(signature);
                    double qualif_j = students[j].GetQualification().GetQualificationForSignature(signature);

                    if (qualif_i > qualif_j)
                    {
                        Student aux = students[i];
                        students[i] = students[j];
                        students[j] = aux;
                    }
                }
            }
        }
        public static List<Student> GetAllStudentsWithGender(Classroom cl, GenderType gender)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < cl.GetStudentCount(); i++)
            {
                Student? st = cl.GetStudentAt(i);
                if(st.GetGender() == gender)
                students.Add(cl.GetStudentAt(i));
            }
            return students;
        }

        public static List<Student> GetStudentsWithGender(Classroom cl, GenderType gender) 
        {
            List<Student> students = GetAllStudentsWithGender(cl, gender);
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

                    if (age_i > age_j)
                    {
                        Student aux = students[i];
                        students[i] = students[j];
                        students[j] = aux;
                    }
                }
            }
        }

        public static NotesStatistic GetStatistics(Classroom cl)
        {
            NotesStatistic note = new NotesStatistic();

            for(int i = 0; i < cl.GetStudentCount(); i++)
            {
                Student? st = cl.GetStudentAt(i);
                double qualification = st.GetQualification().GetAverageNotes();
                {
                    if (qualification >= 9)
                        note.MajorThan9++;
                    else if (qualification >= 7 && qualification > 9)
                        note.MajorThan7++;
                    else if (qualification >= 5 && qualification > 7)
                        note.MajorThan5++;
                    else if (qualification >= 3 && qualification > 5)
                        note.MajorThan3++;
                    else 
                        note.MajorThan0++;
                }
            }
            return note;
        }


    }

    public class NotesStatistic
    {
        public int MajorThan9;
        public int MajorThan7;
        public int MajorThan5;
        public int MajorThan3;
        public int MajorThan0;
    }
}
