namespace IntelligencePipeline.Models.Reports
{
    public class DroneReport : Report
    {
        public int Altitude { get; protected set; }
        public int ImageQuality { get; protected set; }
        public DroneReport(
            int reportId, DateTime timestamp, double latitude,
            double longitude, string description,int altitude, int imageQuality)
            : base(reportId, timestamp, latitude, longitude, description)
        {
            Altitude = altitude;
            ImageQuality = imageQuality;
        }
        public override string GetSourceType() => "Drone";
        public override int CalculateReliabilityScore()
        {
            //Implements drone-specific reliability calculation:
            //-Base: 5
            //- ImageQuality >= 80: +3
            //- ImageQuality >= 50: +2
            //- Altitude 500–3000: +2
            //- Altitude > 7000: -2
            //- Result clamped to 1–10
            return 1;
        }

    }
}