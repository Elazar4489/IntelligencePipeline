using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;
using IntelligencePipeline.Storage;
using System.Reflection.Metadata;
using System.Security.AccessControl;

namespace IntelligencePipeline
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ReportPipeline reportPipeline = new ReportPipeline();
            bool flag = true;
            while (flag)
            {
                printMenu();
                Console.Write("Please enter your choice: ");
                string theChoice = Console.ReadLine();
                if (int.TryParse(theChoice, out int result) && result >= 1 && result <= 3)
                {
                    flag = CheckChoice(result, flag, reportPipeline);
                }
            }
        }






//=======================================================================================================



        private static void DisplayReport(Report report) { }
        private static void DisplayValidatedReports(ReportRepository repository) { }
        private static void DisplayRejectedReports(RejectedReportRepository repository) { }
        //Relationships
        //- Uses: All report types, ReportPipeline, ReportRepository, RejectedReportRepository

        public static void printMenu()
        {
            Console.WriteLine(
                $"=== Welcome to Report Pipeline System ===" +
                $"1. Create new report." +
                $"2. Show Data." +
                $"3. Exit."
                );
        }
        public static bool CheckChoice(int theChoice, bool flag1, ReportPipeline reportPipeline)
        {
            bool result = flag1;
            switch (theChoice)
            {
                case 1:
                    flag1 = CreateNewReport(flag1, reportPipeline);
                    break;
                case 2:
                    flag1 = ShowData(flag1, reportPipeline);
                    break;
                case 3:
                    flag1 = Exit(flag1);
                    break;
                default:
                    Console.WriteLine("Error. Your choice is not exists in system.");
                    break;
            };
            return flag1;
        }
        public static bool CreateNewReport(bool flag2, ReportPipeline reportPipeline)
        {
            string[] input = postInput();
            Report report = getReport(input);
            report.Status = ReportStatus.New;
            reportPipeline.ProcessReport(report);
            return flag2;
        }
        public static bool ShowData(bool flag2, ReportPipeline reportPipeline)
        {
            int theChoice = ChoiceWhatShow();
            if (theChoice == 1)
            {
                reportPipeline.GetValidatedReports();
            }
            else if (theChoice == 2)
            {
                reportPipeline.GetRejectedReports();
            }
            else if (theChoice == 3)
            {
                reportPipeline.DisplayStatistics();
            }
            return flag2;
        }
        public static bool Exit(bool flag2)
        {
            flag2 = false;
            return flag2;
        }
        public static string[] postInput()
        {
            string[] newReportStr = new string[10];
            bool flag = true;
            while (flag)
            {
                Console.Write("Please enter the report type: ");
                string? theType = Console.ReadLine();
                if (Enum.TryParse(theType, true, out ReportTypes correctType))
                {
                    newReportStr[0] = theType;
                    flag = false;
                }
            }
            flag = true;
            while (flag)
            {
                Console.Write("Please enter the timestamp: ");
                string? timestamp = Console.ReadLine();
                if (DateTime.TryParse(timestamp, out DateTime correctTimestamp))
                {
                    newReportStr[1] = timestamp;
                    flag = false;
                }
            }
            flag = true;
            while (flag)
            {
                Console.Write("Please enter the latitude: ");
                string? latitude = Console.ReadLine();
                if (double.TryParse(latitude, out double correctLatitude))
                {
                    newReportStr[2] = latitude;
                    flag = false;
                }
            }
            flag = true;
            while (flag)
            {
                Console.Write("Please enter the longitude: ");
                string? longitude = Console.ReadLine();
                if (double.TryParse(longitude, out double correctType))
                {
                    newReportStr[3] = longitude;
                    flag = false;
                }
            }
            flag = true;
            while (flag)
            {
                Console.Write("Please enter the description: ");
                string? description = Console.ReadLine();
                if (!string.IsNullOrEmpty(description))
                {
                    newReportStr[4] = description;
                    flag = false;
                }
            }
            if (newReportStr[0] == "Drone")
            {
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? Altitude = Console.ReadLine();
                    if (int.TryParse(Altitude, out int result)) { newReportStr[5] = Altitude; flag = false; }
                }
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? ImageQuality = Console.ReadLine();
                    if (int.TryParse(ImageQuality, out int result)) { newReportStr[6] = ImageQuality; flag = false; }
                }
            }
            else if (newReportStr[0] == "Soldier")
            {
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? SoldierName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(SoldierName)) { newReportStr[5] = SoldierName; flag = false; }
                }
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? SoldierID = Console.ReadLine();
                    if (!string.IsNullOrEmpty(SoldierID)) { newReportStr[6] = SoldierID; flag = false; }
                }
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? Unit = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Unit)) { newReportStr[7] = Unit; flag = false; }
                }
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? ConfidenceLevel = Console.ReadLine();
                    if (!string.IsNullOrEmpty(ConfidenceLevel)) { newReportStr[8] = ConfidenceLevel; flag = false; }
                }
            }
            else if (newReportStr[0] == "Radar")
            {
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? Speed = Console.ReadLine();
                    if (int.TryParse(Speed, out int result)) { newReportStr[5] = Speed; flag = false; }
                }
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? Direction = Console.ReadLine();
                    if (int.TryParse(Direction, out int result)) { newReportStr[6] = Direction; flag = false; }
                }
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? Distance = Console.ReadLine();
                    if (int.TryParse(Distance, out int result)) { newReportStr[7] = Distance; flag = false; }
                }
            }
            else if (newReportStr[0] == "Signal")
            {
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? Frequency = Console.ReadLine();
                    if (double.TryParse(Frequency, out double result)) { newReportStr[5] = Frequency; flag = false; }
                }
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? Content = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Content)) { newReportStr[6] = Content; flag = false; }
                }
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? Language = Console.ReadLine();
                    if (!string.IsNullOrEmpty(Language)) { newReportStr[7] = Language; flag = false; }
                }
                flag = true; while (flag)
                {
                    Console.Write("Please enter the");
                    string? SignalStrength = Console.ReadLine();
                    if (int.TryParse(SignalStrength, out int result)) { newReportStr[8] = SignalStrength; flag = false; }
                }

            }
            return newReportStr;





        }
        public static Report getReport(string[] theInput)
        {
            ReportTypes theType = Enum.Parse<ReportTypes>(theInput[0], true);
            return theType switch
            {
                ReportTypes.Drone => new DroneReport(0, DateTime.Parse(theInput[1]), double.Parse(theInput[2]), double.Parse(theInput[3]), theInput[4], int.Parse(theInput[5]), int.Parse(theInput[6])),
                ReportTypes.Soldier => new SoldierReport(0, DateTime.Parse(theInput[1]), double.Parse(theInput[2]), double.Parse(theInput[3]), theInput[4], theInput[5], theInput[6], theInput[7], int.Parse(theInput[8])),
                ReportTypes.Radar => new RadarReport(0, DateTime.Parse(theInput[1]), double.Parse(theInput[2]), double.Parse(theInput[3]), theInput[4], int.Parse(theInput[5]), int.Parse(theInput[6]), int.Parse(theInput[7])),
                ReportTypes.Signal => new SignalReport(0, DateTime.Parse(theInput[1]), double.Parse(theInput[2]), double.Parse(theInput[3]), theInput[4], double.Parse(theInput[5]), theInput[6], Enum.Parse<Language>(theInput[7]), int.Parse(theInput[8]))
            };
        }
        public static int ChoiceWhatShow()
        {
            int theChoice = 0;
            bool flag = true;
            while (flag)
            {
                Console.Write(
                "1. Report Repository." +
                "2. Rejected Report Repository." +
                "3. Display Statistics.");
                string? choice = Console.ReadLine();
                if (int.TryParse(choice, out int res) && res >=1 && res <= 3)
                {
                    theChoice = res;
                    flag = false;
                }
                else { Console.WriteLine("Invalid Choice. Please try again"); }
            }
            return theChoice;
            

        }
    }
    }
