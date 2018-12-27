using System;
namespace StudentRazorPage.Model
{
    public class Student
    {
        public int Id{get;set;}
        //[Required]
        public string Name{get;set;}
        public string Class{get;set;}
        public string address{get;set;}
        public string PhoneNumber{get;set;}
    }
}