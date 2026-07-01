using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class DroneValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
//        Validates:
//            -Report is DroneReport type
//            - Altitude: 100–10000
//            - ImageQuality: 1–100
//Note: Common fields(Timestamp, Latitude, Longitude, Description) are validated by
//BaseValidator.ValidateCommonFields()

        }
    }
  
}