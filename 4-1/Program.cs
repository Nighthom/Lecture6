﻿using System;


namespace _4_1
{

    public class Process
    {
        public Process() { }
        public Process(string process) { this.process = process; }
        public string process = "";
    }
    public class Computer
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Purpose { get; set; }
        public string OperatingSystem { get; set; }
        public int MemoryCapacity { get; set; }
        public int StorageCapacity { get; set; }
        public double ScreenSize { get; set; }

        // 인스턴스 변수
        private string m_nowProcess = "";
        // 클래스 변수
        public static int computerCount = 0;

        public Computer() { }
        public Computer(string brand, string model, string purpose, string operatingSystem, int memoryCapacity, int storageCapacity, double screenSize)
        {
            Brand = brand;
            Model = model;
            Purpose = purpose;
            OperatingSystem = operatingSystem;
            MemoryCapacity = memoryCapacity;
            StorageCapacity = storageCapacity;
            ScreenSize = screenSize;
        }

        public void TurnOn()
        {
            Console.WriteLine("Computer Turn On.");
        }

        public void TurnOff()
        {
            // Turn off the computer
            Console.WriteLine("Computer Turn Off.");
        }

        // 메서드 오버로딩
        // 해당 메서드는 값을 복사해서 내부의 WriteLine 함수에 전달한다.
        // 값 복사에 해당하기 때문에 사용중인 값을 다른 값으로 변경해도 
        // 다른 값에는 영향을 미치지 않는다.
        public void TurnOff(string cause)
        {
            Console.WriteLine("Turnoff cause : " + cause);
            // null로 밀어도 영향 X!
            cause = null;
            TurnOff();
        }
        
        public void Reboot()
        {
            // Reboot the computer
            Console.WriteLine("Computer Reboot.");
        }

        // 메서드 오버로딩
        public void Reboot(string cause)
        {
            Console.WriteLine("Reboot cause : " + cause);
            Reboot();
        }

        public void ExecuteProgram(string programName)
        {
            // Execute a program on the computer
            Console.WriteLine("Execute Program. Name : " + programName);
            m_nowProcess = programName;
        }

        public void SaveFile(string filename)
        {
            Console.WriteLine("Save File. Filename: " + filename);
        }

        public void ConnectToURL(string url)
        {
            Console.WriteLine("Connect To URL : " + url);
        }

        public void GetCurrProcess(Process process)
        {
            process.process = m_nowProcess;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            computer.TurnOn();
            computer.TurnOff();

            computer.TurnOn();
            computer.TurnOff("Access Denied.");

            computer.TurnOn();
            computer.Reboot("Illegal Access Detected.");

            computer.SaveFile("C:\\name\\test.txt");
            computer.ConnectToURL("http://www.naver.com");

            computer.ExecuteProgram("Chrome.exe");

            // 참조 복사 실험 코드
            Process currProcess = new Process();
            computer.GetCurrProcess(currProcess);
            Console.WriteLine("Now Process : " + currProcess.process);
        }
    }
}
