using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class DroneValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            string message = "";
            if (report is DroneReport droneReport)
            {
                if (droneReport.Altitude >= 100 && droneReport.Altitude <= 10000)
                {
                    if (droneReport.ImageQuality >= 1 && droneReport.ImageQuality <= 100)
                    {
                        return ValidationResult.Success();
                    }
                    else { message = "ERROR: ImageQuality must be between 1–100"; }
                }
                else { message = "ERROR: Altitude must be between 100–10000"; }
            }
            else { message = "ERROR: Report is not DroneReport type"; }
            return ValidationResult.Failure(message);
        }
    }
  
}