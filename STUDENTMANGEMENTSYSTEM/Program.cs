using STUDENTMANGEMENTSYSTEM;
using System;
using System.Collections.Generic;
namespace STUDENTMANGEMENTSYSTEM
{
    class Program
    {
        //قائمة لتخزين الطلاب
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            bool running = true;
            //حلقة لتشغيل البرنامج حتى يختار المستخدم الخروج
            while (running)
            {
                Console.WriteLine("\n=== STUDENTMANGEMENTSYSTEM ===");
                Console.WriteLine("1. Add new student ");
                Console.WriteLine("2. Show all student");
                Console.WriteLine("3. Search student");
                Console.WriteLine("4. Ubdate student");
                Console.WriteLine("5. Remove student");
                Console.WriteLine("6. AddGread");
                Console.WriteLine("7. Calculate Average");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ShowAllStudents();
                        break;
                    case "3":
                        SearchStudent();
                        break;
                    case "4":
                        UpdateStudent();
                        break;
                    case "5":
                        RemoveStudent();
                        break;
                    case "6":
                        AddGrade();
                        break;
                    case "7":
                        CalculateAverage();
                        break;
                    case "8":
                        running = false;
                        Console.WriteLine(">> EXIIIIT");
                        break;
                    default:
                        Console.WriteLine(">>   please enter num 1__8  ");
                        break;
                }
            }
        }


        static void AddStudent()
        {
            Console.WriteLine("\n--- Add New Student ---");

            // 1. إدخال الرقم والتحقق من صحته
            Console.Write("Enter Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(">> Error please enter num ");
                return;
            }

            // 2. التحقق من عدم تكرار الرقم
            if (students.Exists(s => s.Id == id))
            {
                Console.WriteLine(">> Error the num found ");
                return;
            }

            // 3. إدخال الاسم والتحقق منه
            Console.Write("Enter Student Name: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine(">> Error the name null");
                return;
            }
            // الشرط الجديد: التحقق من أن الاسم لا يحتوي على أي أرقام
            if (name.Any(char.IsDigit))
            {
                Console.WriteLine(">> Error please dont  enter num.");
                return;
            }

            // 4. الحفظ في القائمة
            Student? newStudent = new Student(id, name);
            students.Add(newStudent);
            Console.WriteLine($">>done {id}'{name}'");
        }
        static void ShowAllStudents()
        {
            Console.WriteLine("\n--- Show All Students ---");

            // 1. التحقق مما إذا كانت القائمة فارغة
            if (students.Count == 0)
            {
                Console.WriteLine(">>    The system embtyy not found students ");
                return; // الخروج من الدالة لعدم وجود بيانات لعرضها
            }

            // 2. المرور على جميع الطلاب وطباعة بياناتهم
            Console.WriteLine("list students :");
            foreach (var student in students)
            {
                Console.WriteLine($"id : {student.Id} | name: {student.Name}");
            }
        }
        static void SearchStudent()
        {
            Console.WriteLine("\n--- Search Student ---");

            // 1. طلب الـ ID والتحقق من صحة المدخلات (Validation)
            Console.Write("Enter Student ID to search: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(">>Error plese enter value true");
                return; // العودة للقائمة الرئيسية
            }

            // 2. استخدام دالة Find للبحث عن الطالب داخل القائمة
            Student? student = students.Find(s => s.Id == id);

            // 3. التحقق من نتيجة البحث وعرضها
            if (student != null)
            {
                Console.WriteLine($">>the student found :");
                Console.WriteLine($" (ID): {student.Id} | name: {student.Name}");
            }
            else
            {
                Console.WriteLine(">> Error the student not found ");
            }
        }
        static void UpdateStudent()
        {
            Console.WriteLine("\n--- Update Student ---");

            // 1. طلب الـ ID والتحقق من صحته
            Console.Write("Enter Student ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(">> Error please enter num true");
                return;
            }

            // 2. البحث عن الطالب في القائمة
            Student? student = students.Find(s => s.Id == id);

            // 3. التحقق من وجود الطالب
            if (student == null)
            {
                Console.WriteLine(">> the student not found");
                return; // الخروج لأن الطالب غير موجود
            }

            // 4. عرض الاسم الحالي وطلب الاسم الجديد
            Console.WriteLine($"neme student now {student.Name}");
            Console.Write("Enter New Name: ");
            string? newName = Console.ReadLine();

            // 5. التحقق من أن الاسم الجديد ليس فارغاً (Validation)
            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine(">> Error pleas enter new name");
                return;
            }

            // 6. تحديث البيانات
            student.Name = newName;
            Console.WriteLine(">> done updet information");
        }
        static void RemoveStudent()
        {
            Console.WriteLine("\n--- Remove Student ---");

            // 1.  ID والتحقق من صح (Validation)
            Console.Write("Enter Student ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(">> Error please enter num true");
                return;
            }

            // 2. البحث عن الطالب في القائمة
            Student? student = students.Find(s => s.Id == id);

            // 3. التحقق من وجود الطالب قبل محاولة حذفه
            if (student == null)
            {
                Console.WriteLine(">> the student not found and i can not remve ");
                return;
            }

            // 4. تأكيد الحذف وتخزين الاسم لطباعته في رسالة النجاح
            string? deletedName = student.Name;
            students.Remove(student); // مسح الطالب من القائمة

            Console.WriteLine($">> done remove student '{deletedName}'!");
        }
        // 6. دالة إضافة علامة لجميع الطلاب (مع فحص الأحرف والأرقام بشكل منفصل)
        // 6. دالة إدخال 8 علامات لكل طالب
        static void AddGrade()
        {
            Console.WriteLine("\n--- Add Grades For All Students ---");

            // التحقق أولاً من وجود طلاب في النظام
            if (students.Count == 0)
            {
                Console.WriteLine(">> The system is empty Please add students first.");
                return;
            }

            // المرور على جميع الطلاب لطلب 8 علامات لكل واحد منهم
            foreach (var student in students)
            {
                Console.WriteLine($"\n>> Entering 8 grades for student: '{student.Name}' (ID: {student.Id})");

                // مسح أي علامات قديمة للطالب حتى لا تتراكم إذا اختار المستخدم هذا الخيار أكثر من مرة بالخطأ
                student.Greads.Clear();

                // حلقة تتكرر 8 مرات لإدخال 8 مواد
                for (int i = 1; i <= 8; i++)
                {
                    bool validInput = false;

                    while (!validInput)
                    {
                        Console.Write($"Enter Grade #{i} (0 - 100): ");
                        string? input = Console.ReadLine();

                        // 1. الفحص الأول: التحقق إذا كان المدخل يحتوي على أحرف
                        if (!double.TryParse(input, out double grade))
                        {
                            Console.WriteLine(">> Error please enter only num.");
                            continue;
                        }

                        // 2. الفحص الثاني: التحقق من النطاق (0 - 100)
                        if (grade < 0 || grade > 100)
                        {
                            Console.WriteLine(">> Error please 0__100.");
                            continue;
                        }

                        // إذا اجتاز الفحصين، يتم حفظ العلامة
                        student.Greads.Add(grade);
                        validInput = true; // الخروج من حلقة الإدخال للمادة الحالية والانتقال للمادة التي تليها
                    }
                }
                Console.WriteLine($">> Done adding 8 grades for '{student.Name}'.");
            }

            Console.WriteLine("\n>> Finished adding all grades for all students!");
        }

        // 7. دالة حساب متوسط العلامات
        static void CalculateAverage()
        {
            Console.WriteLine("\n--- Calculate Average For All Students ---");

            // التحقق من وجود طلاب في النظام
            if (students.Count == 0)
            {
                Console.WriteLine(">> The system is empty No students found.");
                return;
            }

            // المرور على جميع الطلاب لحساب وعرض متوسط كل طالب
            foreach (var student in students)
            {
                // إذا كان الطالب لا يمتلك أي علامات نتخطاه ونطبع رسالة
                if (student.Greads.Count == 0)
                {
                    Console.WriteLine($">> No grades found for '{student.Name}' (ID: {student.Id}).");
                    continue; // الانتقال للطالب التالي في القائمة
                }

                // حساب المجموع للطالب الحالي
                double sum = 0;
                foreach (double grade in student.Greads)
                {
                    sum += grade;
                }

                // حساب المتوسط
                double average = sum / student.Greads.Count;

                // طباعة النتيجة وتنسيقها لتظهر برقمين عشريين (0.00)
                Console.WriteLine($">> Average for '{student.Name}' (ID: {student.Id}) is: {average:F2}");
            }
        }
    }
}