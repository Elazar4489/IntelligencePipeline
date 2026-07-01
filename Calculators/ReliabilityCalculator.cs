using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    class ReliabilityCalculator
    {
        public int Calculate(Report report)
        {
            """
            Calls report.CalculateReliabilityScore() and ensures result is 1–10.
            """
        }
    }
}