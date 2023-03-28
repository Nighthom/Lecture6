using System;


namespace _4_3
{
    public class Student
    {
        // Properties
        public string Name { get; set; }
        public string StudentNumber { get; set; }
        public string Major { get; set; }
        public int Grade { get; set; }
        public double Score { get; set; }
        public double AttendanceRate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Student()
        {
            Name = "";
            StudentNumber = "";
            Major = "";
            Grade = 0;
            Score = 0.0;
            AttendanceRate = 0.0;
            Email = "";
            PhoneNumber = "";
        }
        // Constructor
        public Student(string name, string studentNumber, string major, int grade, double score, double attendanceRate, string email, string phoneNumber)
        {
            Name = name;
            StudentNumber = studentNumber;
            Major = major;
            Grade = grade;
            Score = score;
            AttendanceRate = attendanceRate;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        // Methods
        public void CheckAttendance()
        {
            Console.WriteLine($"{Name} 학생이 출석하였습니다.");
        }

        public void InputScore(double score)
        {
            Score = score;
            Console.WriteLine($"{Name} 학생의 성적이 입력되었습니다.");
        }

        public void GetScore()
        {
            Console.WriteLine($"{Name} 학생의 성적은 {Score}점 입니다.");
        }

        public void SendEmail(string message)
        {
            Console.WriteLine($"{Email}로 이메일을 발송했습니다. 내용: {message}");
        }

        public void MakePhoneCall(string phoneNumber)
        {
            Console.WriteLine($"{phoneNumber}로 전화를 걸었습니다.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("윤승준", "20180679", "컴퓨터공학부" , 3,3.9, 1.0, "qqq991124@naver.com", "01022170710");
            student.SendEmail("Message");
            student.MakePhoneCall("01021111111");
        }
    }
}
