using IntelligencePipeline.Models.Reports;
using System.Collections;
using System.Reflection;

namespace IntelligencePipeline.Calculators
{
    class ReliabilityCalculator
    {
        public int Calculate(Report report)
        {
            int reliabilityScore = 0;

            if (report is DroneReport drone)
            {
                reliabilityScore = 5;
                if (drone.ImageQuality >= 80)
                {
                    reliabilityScore += 3;
                }
                else if (drone.ImageQuality >= 50)
                {
                    reliabilityScore += 2;
                }
                if (drone.Altitude >= 500 && drone.Altitude <= 3000)
                {
                    reliabilityScore += 2;
                }
                if (drone.Altitude > 7000)
                {
                    reliabilityScore -= 2;
                }
            }
            else if (report is SoldierReport soldier)
            {
                reliabilityScore = 4 + soldier.ConfidenceLevel;
                if (ContainsKeyword(soldier.Description, "weapon", "vehicle", "movement", "explosion"))
                {
                    reliabilityScore += 1;
                }
            }
            else if (report is RadarReport radar)
            {
                reliabilityScore = 6;
                if (radar.Distance >= 500 && radar.Distance <= 30000)
                {
                    reliabilityScore += 2;
                }
                if (radar.Speed >=10 && radar.Speed <= 900)
                {
                    reliabilityScore += 1;
                }
                if (radar.Distance > 70000)
                {
                    reliabilityScore -= 2;
                }
                if (radar.Speed > 1500)
                {
                    reliabilityScore -= 2;
                }
            }
            else if (report is SignalReport signal)
            {
                reliabilityScore = 5;
                if (signal.SignalStrength>= -40)
                {
                    reliabilityScore += 3;
                }
                else if (signal.SignalStrength >= -70)
                {
                    reliabilityScore += 2;
                }
                else if (signal.SignalStrength < -100)
                {
                    reliabilityScore -= 2;
                }
                if (ContainsKeyword(signal.Content, "attack", "target", "border", "vehicle"))
                {
                    reliabilityScore += 1;
                }
            }
            return reliabilityScore;
            





            //report.CalculateReliabilityScore();
            //    and ensures result is 1–10.
            
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