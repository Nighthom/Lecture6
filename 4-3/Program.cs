using System;
using System.Collections.Generic;

public class PhoneNumber
{
    public string phoneNumber = "";
}
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

        // 인스턴스 변수
        private string PhoneNumber;

        // 클래스 변수
        public static int studentCount = 0;

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
            studentCount++;
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
            studentCount++;
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

        // 성적 리스트를 받아서 평균 점수 입력(메서드 오버로딩)
        public void InputScore(List<double> scores)
        {
            double sum = 0;

            foreach(var score in scores)
            {
                sum += score;
            }

            double average = sum / scores.Count;

            Score = Math.Round(average, 2);
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
        // 해당 메서드는 값을 복사해서 내부의 WriteLine 함수에 전달한다.
        // 값 복사에 해당하기 때문에 사용중인 값을 다른 값으로 변경해도 
        // 다른 값에는 영향을 미치지 않는다.
        public void MakePhoneCall(string phoneNumber)
        {
            Console.WriteLine($"{phoneNumber}로 전화를 걸었습니다.");
            // null로 밀어도 원본 Data에는 영향 X!
            phoneNumber = null;
        }

        // 참조 복사
        public void GetPhoneNumber(PhoneNumber phoneNumber)
        {
            phoneNumber.phoneNumber = PhoneNumber;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("윤승준", "20180679", "컴퓨터공학부" , 3,3.9, 1.0, "qqq991124@naver.com", "01022170710");
            student1.CheckAttendance();
            student1.GetScore();
            student1.InputScore(4.5);
            student1.GetScore();
            student1.SendEmail("Message");
            student1.MakePhoneCall("01021111111");

            List<double> scores = new List<double>();
            scores.Add(4.5);
            scores.Add(4.3);
            scores.Add(4.0);
            student1.InputScore(scores);
            student1.GetScore();

            Student student2 = new Student("지승하", "20182324", "컴퓨터공학부", 3, 3.9, 1.0, "asdasd@naver.com", "01012345679");

            Console.WriteLine("학생 명수 : " + Student.studentCount);

            // 참조 복사 테스트
            PhoneNumber phoneNumber = new PhoneNumber();
            student2.GetPhoneNumber(phoneNumber);
            Console.WriteLine("현재 전화번호 : " + phoneNumber.phoneNumber);
        }
    }
}
