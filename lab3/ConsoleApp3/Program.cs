using System;
using System.Diagnostics;

enum Education {
    Specialist,
    Bachelor,
    SecondEducation
}
class Exam {
    string subjectName {  get; set; } //auto-realization property
    int grade {  get; set; } //auto-realization property
    DateTime examDate { get; set; }  //auto-realization property
    
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
        examDate = DateTime.MinValue    }
}