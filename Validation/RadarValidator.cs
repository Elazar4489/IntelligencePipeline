using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class RadarValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            string message = "";
            if (report is RadarReport radarReport)
            {
                if (radarReport.Speed >= 0 && radarReport.Speed <= 2000)
                {
                    if (radarReport.Direction >= 0 && radarReport.Direction <= 360)
                    {
                        if (radarReport.Distance>= 100 && radarReport.Distance <= 100000)
                        {
                            return ValidationResult.Success();
                        }
                        else { message = "ERROR: Distance must be between 100–100000"; }
                    }
                    else { message = "ERROR: Direction must be between 0–360"; }
                }
                else { message = "ERROR: Speed must be between 0–2000"; }
            }
            else { message = "ERROR: Report is not RadarReport type"; }
            return ValidationResult.Failure(message);
            
        }
    }
}