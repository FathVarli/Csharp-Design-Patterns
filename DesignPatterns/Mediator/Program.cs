using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            //ara bulucu
            //farklı sistemleri bir araya getirmek için kullanılır.

            Mediator mediator = new Mediator();

            Teacher fatih = new Teacher(mediator);
            fatih.Name = "Fatih";

            mediator.Teacher = fatih;

            Student irem = new Student(mediator);
            irem.Name = "irem";

            Student zeynep = new Student(mediator);
            zeynep.Name = "zeynep";

            mediator.Students = new List<Student> { irem, zeynep };

            fatih.SendNewImageUrl("slide1.jpg");

            fatih.RecieveQuestion("is it true?", irem);


            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;
        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }

    }

    class Teacher : CourseMember
    {
        public string Name { get; set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0}: {1}", student.Name, question);
                
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question: {0},{1}", student.Name, answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get;  set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} received image: {0}", url,Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("{1} received answer {0}", answer,Name);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question,student);
        }

        public void SendAnswer(string answer,Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
