using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    class PriorityCalculator
    {
        public Priority Calculate(Report report)
        {
            //"""
            //            Implements priority rules:
            //- Critical: missile/explosion/attack/fire keywords, Radar Speed >= 800, Signal with target
            //AND attack
            //- High: weapon/suspicious/border keywords, Drone Altitude < 500, Radar Speed >= 400,
            //Soldier ConfidenceLevel >= 4 with movement
            //- Medium: movement/vehicle/activity keywords, Radar Speed >= 120, ReliabilityScore >=
            //7
            //- Low: default
            //"""
        }
        private bool ContainsKeyword(string text, params string[] keywords)
        {
            //"""
            //Case-insensitive keyword search.
            //"""
        }
    }
}