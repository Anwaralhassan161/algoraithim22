using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algoraithim22
{
    using System;
    using System.Collections.Generic;

    class Student
    {

        // تعريف فئة الطالب
        
        
            public int Id { get; set; } 
            public string Name { get; set; } 
            public double Exam1 { get; set; } 
            public double Exam2 { get; set; } 

            // دالة لحساب المحصلة
            public double CalculateScore()
            {
                return (Exam1 + Exam2) / 2; 
            }

            
            public string GetGrade()
            {
                double score = CalculateScore();
                if (score < 60)
                    return "راسب"; 
                else if (score < 75)
                    return "جيد"; 
                else if (score < 85)
                    return "جيد جداً"; 
                else
                    return "ممتاز"; 
            }
        }

        // الفئة الرئيسية للبرنامج
        class Program
        {
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>(); // إنشاء قائمة لتخزين الطلاب

                while (true)
                {
                    Console.Write("أدخل رقم الطالب (أو اكتب 'خروج' لإنهاء): ");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "خروج") 
                        break;

                    int id;
                    if (!int.TryParse(input, out id)) // التحقق من صحة الرقم المدخل
                    {
                        Console.WriteLine("يرجى إدخال رقم صحيح.");
                        continue; 
                    }

                    Console.Write("أدخل اسم الطالب: ");
                    string name = Console.ReadLine(); 

                    double exam1, exam2;

                    // إدخال علامة الاختبار الأول مع التحقق من صحتها
                    Console.Write("أدخل علامة الاختبار الأول: ");
                    while (!double.TryParse(Console.ReadLine(), out exam1))
                    {
                        Console.WriteLine("يرجى إدخال قيمة صحيحة للاختبار الأول.");
                    }

                    // إدخال علامة الاختبار الثاني مع التحقق من صحتها
                    Console.Write("أدخل علامة الاختبار الثاني: ");
                    while (!double.TryParse(Console.ReadLine(), out exam2))
                    {
                        Console.WriteLine("يرجى إدخال قيمة صحيحة للاختبار الثاني.");
                    }

                    // إنشاء كائن طالب جديد وإضافته إلى القائمة
                    Student student = new Student { Id = id, Name = name, Exam1 = exam1, Exam2 = exam2 };
                    InsertStudent(students, student); // إضافة الطالب إلى القائمة مع الفرز
                }

                // عرض قائمة الطلاب مرتبة حسب المحصلة
                Console.WriteLine("\nقائمة الطلاب مرتبة حسب المحصلة:");
                foreach (var student in students)
                {
                    Console.WriteLine("رقم الطالب: {student.Id}, اسم الطالب: {student.Name}, المحصلة: {student.CalculateScore():F2}, التقدير: {student.GetGrade()}");
                }
            }

            // دالة لإضافة طالب إلى القائمة مع الفرز
            static void InsertStudent(List<Student> students, Student student)
            {
                students.Add(student); 
                students.Sort((s1, s2) => s1.CalculateScore().CompareTo(s2.CalculateScore())); // فرز القائمة حسب المحصلة
            }
        }
    }


        
    

