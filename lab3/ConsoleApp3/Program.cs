using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Collections;



enum Education {
    Specialist,
    Bachelor,
    SecondEducation
}
class Exam {
    public string subjectName {  get; set; } //auto-realization property
    public int grade {  get; set; } //auto-realization property
    public DateTime examDate { get; set; }  //auto-realization property
    
    public Exam(string Subject, int Grade, DateTime ExamDate) //constructor with params
    {
        subjectName = Subject;
        grade = Grade;
        examDate = ExamDate;
    }

    public Exam()  //constructor without params and default values
    {
        subjectName = " ";
        grade = 0;
        examDate = DateTime.MinValue;
    }
    public override string ToString()
    {
        return base.ToString();
    }
}
class Student
{
    private string Person;
    private string Education;
    private int GroupNumber;
    private Exam[]? exams;
    private List<Exam> examsList = new List<Exam>();


    public Student(string person, string education, int groupNumber) //constructor with params
    {
        Person = person;
        Education = education;
        GroupNumber = groupNumber;
    }
    public Student()  //constructor without params and default values
    {
        Person = " ";
        Education = " ";
        GroupNumber = 0;
        exams = null;
    }

    public string PersonGetterAndSetter
    {
        get
        {
            return Person;
        }
        set
        {
            this.Person = value;
        }
    }
    public string EducationGetterAndSetter
    {
        get
        {
            return Education;
        }
        set
        {
            this.Education = value;
        }
    }
    public int GroupNumberGetterAndSetter
    {
        get
        {
            return GroupNumber;
        }
        set
        {
            this.GroupNumber = value;
        }
    }
    public Exam[] ExamGetterAndSetter
    {
        get
        {
            return exams;
        }
        set
        {
            this.exams = value;
        }
    }

    public double averageExamGrade {
        
        get {
            if (examsList.Count > 0)
            {
                return examsList.Average(exams => exams.grade);
            }
            else
            {
                return 0.0;
            }
        }
    }
    public bool this[Education educationForm]    
    {
        get
        {
            if (this != null)
            {
                return true;

            }
            else return false;
        }
    }
    public void AddExams(params Exam[] exams)
    {
        examsList.AddRange(exams);
    }
    public override string ToString()
    {
        return $"Student Name: {Person}, Student Education Form: {Education}, Group Number: {GroupNumber}, Exam list: {examsList}";
    }
    public virtual string ToShortString()
    {
        return $"Student Name: {Person}, Student Education Form: {Education}, Group Number: {GroupNumber}, Average Grade: {averageExamGrade}";
    }
    
}
class main1
{
    public static void Main()
    {

        Student student1 = new Student("Dmytro", "Bachelor", 23);
        Exam exam1 = new Exam();
        Console.WriteLine(student1.ToShortString());
        Console.WriteLine(student1[Education.Specialist]);
        Console.WriteLine(student1[Education.Bachelor]);
        Console.WriteLine(student1[Education.SecondEducation]);
        //exam1.subjectName = 
        //student1.GroupNumberGetterAndSetter = 23;
        //int[] arrayExam1 = {90};
       // student1.ExamGetterAndSetter = arrayExam1;
        //Console.WriteLine(student1.ToString());
        student1.AddExams(
            new Exam("Math", 90, DateTime.Now),
            new Exam("Physics", 85, DateTime.Now),
            new Exam("History", 78, DateTime.Now)
        );
        Console.WriteLine(student1.ToString());
        Console.ReadLine();

    }   

}
 

