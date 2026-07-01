using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class SoldierValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            """
                        Validates:
            - Report is SoldierReport type
            - SoldierName: 2–50 characters
            - SoldierID: exactly 7 digits
            - Unit: 2–50 characters
            - ConfidenceLevel: 1–5
            Note: Common fields are validated by BaseValidator.ValidateCommonFields()
            """

        }
    }
}