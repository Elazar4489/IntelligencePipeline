using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    class PriorityCalculator
    {
        public Priority Calculate(Report report)
        {
            Priority priority = new Priority();
            if (ContainsKeyword(report.Description, "missile","explosion","attack","fire")||
            (report is RadarReport radar && radar.Speed >= 800) ||
            (report is SignalReport signal && ContainsKeyword(signal.Content, "target", "missile", "explosion", "attack", "fire")))
            {
                priority = Priority.Critical;
            }
            else if (ContainsKeyword(report.Description, "weapon", "suspicious", "border") ||
                (report is DroneReport drone && drone.Altitude < 500)||
                (report is RadarReport radar1 && radar1.Speed >= 400)||
                (report is SoldierReport soldier && soldier.ConfidenceLevel >=4 && ContainsKeyword(soldier.Description, "movement"))
                )
            {
                priority = Priority.High;
            }
            else if (ContainsKeyword(report.Description, "movement", "vehicle", "activity")||
                (report is RadarReport radar2 && radar2.Speed >= 120)||
                (report.ReliabilityScore >= 7)
                )
            {
                priority = Priority.Medium;
            }
            else
            {
                priority = Priority.Low;
            }
            return priority;
        }
        private bool ContainsKeyword(string text, params string[] keywords)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            foreach (string keyword in keywords)
            {
                if (text.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}