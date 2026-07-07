using System;
using System.Collections.Generic;
using System.Text;

namespace STUDENTMANGEMENTSYSTEM
{
    public class Student 
    {
        //نعرف خصائص تدل على كل طالب 
        public int Id {  get; set; }
        public string Name { get; set; }
        public List<double> Greads {get; set;  }
       //باني ل كلاس الطالب 
        public Student(int id , string name ) 
        { 
            Id = id;
            Name = name;
            Greads = new List<double>();

        }
}
}
