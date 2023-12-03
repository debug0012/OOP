using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Collections;


public interface IDateAndCopy
{
    object DeepCopy();
    DateTime Date { get; set; }
}
public class Exam1 : IDateAndCopy
{
    public string SubjectName { get; set; }
    public int Grade { get; set; }
    public DateTime ExamDate { get; set; }

    public Exam1(string Subject, int Grade, DateTime ExamDate) //constructor with params
    {
        this.SubjectName = Subject;
        this.Grade = Grade;
        this.ExamDate = ExamDate;
    }
    // Реалізація інтерфейсу IDateAndCopy
    public object DeepCopy()
    {
        return new Exam1(SubjectName, Grade, ExamDate){ SubjectName = this.SubjectName, Grade = this.Grade, ExamDate = this.ExamDate };
    }

    public DateTime Date
    {
        get { return ExamDate; }
        set { ExamDate = value; }
    }
}

public class Person : IDateAndCopy
{
    protected string name;
    protected string surname;
    protected DateTime birthDate;

    public Person(string name, string surname, DateTime birthDate)
    {
        this.name = name;
        this.surname = surname;
        this.birthDate = birthDate;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    // Реалізація інтерфейсу IDateAndCopy
    public object DeepCopy()
    {
        return new Person(Name, Surname, BirthDate) { name = this.Name, surname = this.Surname, birthDate = this.BirthDate };
    }

    public DateTime Date
    {
        get { return BirthDate; }
        set { BirthDate = value; }
    }

    // Перевизначення методу Equals
    public override bool Equals(object obj)
    {
        if (obj is Person otherPerson)
        {
            return this.name == otherPerson.name &&
                   this.surname == otherPerson.surname &&
                   this.birthDate == otherPerson.birthDate;
        }
        return false;
    }

    // Перевизначення операції ==
    public static bool operator ==(Person person1, Person person2)
    {
        if (ReferenceEquals(person1, person2))
            return true;

        if (person1 is null || person2 is null)
            return false;

        return person1.Equals(person2);
    }

    // Перевизначення операції !=
    public static bool operator !=(Person person1, Person person2)
    {
        return !(person1 == person2);
    }

    // Перевизначення методу GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine(name, surname, birthDate);
    }

}

public class Student1 : Person, IDateAndCopy
{

    private string Education;
    private int groupNumber;
    private ArrayList testsList;
    private ArrayList examsList;

    // Новий конструктор для класу Student
    public Student1(Person person, string educationForm, int groupNumber)
        : base(person.Name, person.Surname, person.BirthDate)
    {
        this.Education = educationForm;
        this.groupNumber = groupNumber;
        testsList = new ArrayList();
        examsList = new ArrayList();
    }

    
    public Student1() : base("", "", DateTime.Now)
    {
        Education = "";
        groupNumber = 0; 
        testsList = new ArrayList();
        examsList = new ArrayList();
    }

    // Властивість типу Person
    public Person StudentPerson
    {
        get
        {
            return new Person(Name, Surname, BirthDate);
        }
        set
        {
            if (value != null)
            {
                Name = value.Name;
                Surname = value.Surname;
                BirthDate = value.BirthDate;
            }
        }
    }

    public double AverageGrade
    {
        get
        {
            if (examsList.Count == 0)
                return 0; // Повертає 0, якщо немає зданих іспитів

            double sum = 0;
            foreach (Exam1 exam in examsList)
            {
                sum += exam.Grade;
            }

            return sum / examsList.Count;
        }
    }

    public void AddExams(params Exam1[] exams)
    {
        if (exams != null)
        {
            foreach (Exam1 exam in exams)
            {
                examsList.Add(exam);
            }
        }
    }
    public void AddTests(params Test[] tests)
    {
        if (tests != null)
        {
            foreach (Test test in tests)
            {
                testsList.Add(test);
            }
        }
    }

    public override string ToString()
    {
        string studentInfo = $"Student: {Name} {Surname}, Birth Date: {BirthDate.ToShortDateString()}, " +
                             $"Education Form: {Education}, Group Number: {groupNumber}, ";

        // Additional info for tests
        studentInfo += "Tests:\n";
        foreach (Test test in testsList)
        {
            studentInfo += $"{test}\n";
        }

        // Additional info for exams
        studentInfo += "Exams:\n";
        foreach (Exam1 exam in examsList)
        {
            studentInfo += $"{exam}\n";
        }

        return studentInfo;
    }

    public virtual string ToShortString()
    {
        string studentShortInfo = $"Student: {Name} {Surname}, Birth Date: {BirthDate.ToShortDateString()}, " +
               $"Education Form: {Education}, Group Number: {groupNumber}, Average Grade: {AverageGrade}";
        return studentShortInfo;
    }

    public ArrayList ExamsList
    {
        get { return examsList; }
        set { examsList = value; }
    }

    public ArrayList TestsList
    {
        get { return testsList; }
        set { testsList = value; }
    }

    // Реалізація інтерфейсу IDateAndCopy
    public virtual object DeepCopy()
    {
        Student1 copiedStudent = new Student1(this.StudentPerson, this.Education, this.groupNumber);

        // Копіювання списку заліків
        foreach (Test test in TestsList)
        {
            copiedStudent.TestsList.Add(test);
        }

        // Копіювання списку іспитів
        foreach (Exam1 exam in ExamsList)
        {
            copiedStudent.ExamsList.Add(new Exam1(exam.SubjectName, exam.Grade, exam.ExamDate));
        }
            return copiedStudent;
    }

    // Властивість для отримання та встановлення дати з базового класу
    public DateTime DateOfBirth
    {
        get { return BirthDate; }
        set { BirthDate = value; }
    }

    public int GroupNumber
    {
        get { return groupNumber; }
        set
        {
            if (value < 100 || value > 599)
            {
                throw new ArgumentOutOfRangeException("GroupNumber",
                    "Group number must be between 100 and 599.");
            }
            groupNumber = value;
        }
    }

    public IEnumerable GetAllAssessments()
    {
        foreach (Test test in testsList)
        {
            yield return test;
        }

        foreach (Exam1 exam in examsList)
        {
            yield return exam;
        }
    }
    // Ітератор з параметром для перебору іспитів з оцінкою більше заданого значення
    public IEnumerable<Exam1> GetExamsWithGradeGreaterThan(int thresholdGrade)
    {
        return examsList.OfType<Exam1>().Where(exam => exam.Grade > thresholdGrade);
    }
}
public class Test
{
   
    public string SubjectName { get; set; }

    public bool Passed { get; set; }

    public Test(string subjectName, bool passed)
    {
        SubjectName = subjectName;
        Passed = passed;
    }

    public Test()
    {
        SubjectName = "DefaultSubject";
        Passed = false;
    }
    public override string ToString()
    {
        return $"Subject: {SubjectName}, Passed: {Passed}";
    }
}
enum Education
{
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
        //Console.WriteLine(student1.ToString());
        //
        //
        Console.WriteLine("Going to lab4:");
        Person person1 = new Person("Dmytro", "Alekseiev", new DateTime(2004, 04, 01));
        Person person2 = new Person("Dmytro", "Alekseiev", new DateTime(2004, 04, 01));
        Console.WriteLine("Reference equality: " + (person1 == person2));
        Console.WriteLine("Object equality: " + person1.Equals(person2));
        Console.WriteLine("Hash code for person1: " + person1.GetHashCode());
        Console.WriteLine("Hash code for person2: " + person2.GetHashCode());

        Student1 student11 = new Student1(person1, "Bachelor", 23);
        student11.AddExams(new Exam1("Math", 90, new DateTime(2023, 11, 28)));
        student11.AddExams(new Exam1("IIS", 75, new DateTime(2023,11, 29)));
        student11.AddTests(new Test("OOP", true));
        student11.AddTests(new Test("English", true));
        Console.WriteLine(student11.ToString());
        Console.WriteLine(student11.AverageGrade);

        
        Student1 copiedStudent = (Student1)student11.DeepCopy();
        // Зміни в оригінальному об'єкті
        student11.Name = "Paul";
        
        // Виведення копії та оригіналу
        Console.WriteLine("Original Student:");
        Console.WriteLine(student11.ToString());

        Console.WriteLine("\nCopied Student (Deep Copy):");
        Console.WriteLine(copiedStudent.ToString());

        try
        {
            student11.GroupNumber = 799;
        }
        catch (Exception ex) {
                Console.WriteLine($"Exception Message: {ex.Message}");
        }
        Console.WriteLine("Group number: " + student11.GroupNumber);

        Console.WriteLine("List of Exams and Tests:");
        foreach (var assessment in student11.GetAllAssessments())
        {
            Console.WriteLine(assessment);
        }
        Console.WriteLine("List of Exams with Grade Above 85:");
        foreach (var examAboveValue in student11.GetExamsWithGradeGreaterThan(85))
        {
            Console.WriteLine(examAboveValue);
        }

        Console.ReadLine();


        
        
    }   

}
 

