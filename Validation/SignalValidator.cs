using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class SignalValidator: BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            """
                        Validates:
            - Report is SignalReport type
            - Frequency: 1.0–3000.0
            - Content: 5–1000 characters
            - Language: valid enum value
            - SignalStrength: -120–0
            Note: Common fields are validated by BaseValidator.ValidateCommonFields()
            """
        }
    }
}