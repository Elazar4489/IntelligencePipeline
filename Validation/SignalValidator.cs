using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System.Reflection.Metadata;

namespace IntelligencePipeline.Validation
{
    class SignalValidator: BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            string message = "";
            if (report is SignalReport signalReport)
            {
                if (signalReport.Frequency >= 1.0 && signalReport.Frequency <= 3000.0)
                {
                    if (signalReport.Content.Length >= 5 && signalReport.Content.Length <= 1000)
                    {
                        if (Enum.IsDefined(typeof(Language), signalReport.Language))
                        {
                            if (signalReport.SignalStrength >= -120 && signalReport.SignalStrength <= 0)
                            {
                                return ValidationResult.Success();
                            }
                            else { message = "ERROR: SignalStrength must be between -120–0"; }
                        }
                        else { message = "ERROR: Language invalid enum value"; }
                    }
                    else { message = "ERROR: Content must be between 5–1000 characters"; }
                }
                else { message = "ERROR: Frequency must be between 1.0–3000.0"; }
            }
            else { message = "ERROR: Report is not SignalReport type"; }
            return ValidationResult.Failure(message);
        }
    }
}