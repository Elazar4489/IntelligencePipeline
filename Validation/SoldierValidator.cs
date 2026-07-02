using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class SoldierValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            string message = "";
            if (report is SoldierReport soldierReport)
            {
                if (soldierReport.SoldierName.Length >= 2 && soldierReport.SoldierName.Length <= 50)
                {
                    if (soldierReport.SoldierID.Length == 7)
                    {
                        if (soldierReport.Unit.Length >= 2 && soldierReport.Unit.Length <= 50)
                        {
                            if (soldierReport.ConfidenceLevel >= 1 && soldierReport.ConfidenceLevel <= 5)
                            {
                                return ValidationResult.Success();
                            }
                            else { message = "ERROR: ConfidenceLevel must be between 1–5"; }
                        }
                        else { message = "ERROR: Unit must be between 2–50 characters"; }
                    }
                    else { message = "ERROR: SoldierID must be  exactly 7 digits"; }
                }
                else { message = "ERROR: SoldierName must be between 2–50 characters"; }
            }
            else { message = "ERROR: Report is not SoldierReport type"; }
            
            return ValidationResult.Failure(message);

        }
    }
}