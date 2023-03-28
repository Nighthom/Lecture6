using System;


namespace _4_1
{
    public class Computer
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Purpose { get; set; }
        public string OperatingSystem { get; set; }
        public int MemoryCapacity { get; set; }
        public int StorageCapacity { get; set; }
        public double ScreenSize { get; set; }

        public void TurnOn()
        {
            Console.WriteLine("Computer Turn On.");
        }

        public void TurnOff()
        {
            // Turn off the computer
            Console.WriteLine("Computer Turn Off.");
        }

        public void Reboot()
        {
            // Reboot the computer
            Console.WriteLine("Computer Reboot.");
        }

        public void ExecuteProgram(string programName)
        {
            // Execute a program on the computer
            Console.WriteLine("Execute Program. Name : " + programName);
        }

        public void SaveFile(string filename)
        {
            Console.WriteLine("Save File. Filename: " + filename);
        }

        public void ConnectToURL(string url)
        {
            Console.WriteLine("Connect To URL : " + url);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            computer.TurnOn();
            computer.TurnOff();

            computer.SaveFile("C:\\name\\test.txt");
            computer.ConnectToURL("http://www.naver.com");
        }
    }
}
