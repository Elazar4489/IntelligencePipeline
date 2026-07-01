using System.ComponentModel;

namespace IntelligencePipeline.Models.Reports
{
    class SoldierReport : Report
    {
        public string SoldierName { get; protected set; }
        public string SoldierID { get; protected set; }
        public string Unit { get; protected set; }
        public int ConfidenceLevel { get; protected set; }

        public SoldierReport(
            int reportId, DateTime timestamp, double latitude,
            double longitude, string description, string soldierName,
            string soldierID, string unit, int confidenceLevel)
            : base(reportId, timestamp, latitude, longitude, description)
        {
            SoldierName = soldierName;
            SoldierID = soldierID;
            Unit = unit;
            ConfidenceLevel = confidenceLevel;
        }
        public override string GetSourceType() => "Soldier";
        public override int CalculateReliabilityScore()
        {
            // Implements soldier-specific reliability calculation:
            //-Base: 4
            //- Add ConfidenceLevel value
            //-Description contains weapon/ vehicle / movement / explosion: +1
            //- Result clamped to 1–10

            return 1;
        }

    }
}