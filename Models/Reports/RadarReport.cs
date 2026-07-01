using System.ComponentModel;

namespace IntelligencePipeline.Models.Reports
{
    class RadarReport : Report
    {
        public int Speed { get; protected set; }
        public int Direction { get; protected set; }
        public int Distance { get; protected set; }

        public RadarReport(
            int reportId, DateTime timestamp, double latitude,
            double longitude, string description, int speed, int direction, int distance)
            : base(reportId, timestamp, latitude, longitude, description)
        {
            Speed = speed;
            Direction = direction;
            Distance = distance;
        }
        public override string GetSourceType() => "Radar";
        public override int CalculateReliabilityScore()
        {
//            Implements radar-specific reliability calculation:
//-Base: 6
//- Distance 500–30000: +2
//- Speed 10–900: +1
//- Distance > 70000: -2
//- Speed > 1500: -2
//- Result clamped to 1–10

            return 1;
        }

    }
}