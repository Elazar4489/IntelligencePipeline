using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    class ClassificationCalculator
    {
        public Classification Calculate(Report report) 
        {
            Classification classification = new Classification();
            if (report.Priority == Priority.Critical||(report is SignalReport signal && ContainsKeyword(signal.Content, "target", "attack", "missile")))
            {
                classification = Classification.TopSecret;
            }
            else if (report.Priority == Priority.High || report is SignalReport || ContainsKeyword(report.Description, "border ", "weapon"))
            {
                classification = Classification.Secret;
            }
            else if (report.Priority == Priority.Medium || report is SoldierReport)
            {
                classification = Classification.Restricted;
            }
            else
            {
                classification = Classification.Unclassified;
            }
            return classification;


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