using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class RadarValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            """
                        Validates:
            - Report is RadarReport type
            - Speed: 0–2000
            - Direction: 0–360
            - Distance: 100–100000
            Note: Common fields are validated by BaseValidator.ValidateCommonFields()
            """
        }
    }
}