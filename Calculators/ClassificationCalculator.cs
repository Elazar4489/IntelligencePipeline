using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    class ClassificationCalculator
    {
        public Classification Calculate(Report report) 
        {
            """
                        Implements classification rules:
            - TopSecret: Priority=Critical OR Content contains target/attack/missile
            - Secret: Priority=High OR SourceType=Signal OR Description contains weapon/border
            - Restricted: Priority=Medium OR SourceType=Soldier
            - Unclassified: default
            
            """
        }
        private bool ContainsKeyword(string text, params string[] keywords)
        {
            """
            //?
            """
        }
    }
}