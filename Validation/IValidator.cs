using IntelligencePipeline.Models.Reports;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IntelligencePipeline.Validation
{
    interface IValidator
    {
        ValidationResult Validate(Report report);
    }

    abstract class BaseValidator : IValidator
    {
        public ValidationResult Validate(Report report)
        {
            ValidationResult validationResult = ValidateCommonFields(report);
            if (validationResult.IsValid)
            {
                validationResult = ValidateSpecificFields(report);
            }
            return validationResult;

//            Template method that validates both common and specific fields:
//            1.Calls ValidateCommonFields(report) - validates shared fields
//            2.If common validation passes, calls ValidateSpecificFields(report) -validates
//type - specific fields
//3.Returns ValidationResult indicating success or failure
        }
        protected ValidationResult ValidateCommonFields(Report report)
        {
            string message = "";
            if (report.Timestamp.Year >= 2020 && report.Timestamp <= DateTime.Now)
            {
                if (report.Latitude >= 29.5000 && report.Latitude <= 33.5000)
                {
                    if (report.Longitude >= 34.0000 && report.Longitude <= 36.0000)
                    {
                        if (report.Description.Length >= 10 && report.Description.Length <= 500)
                        {
                            return ValidationResult.Success();
                        }
                        else { message = "ERROR: Timestamp Cannot be in the future, cannot be before 2020-01-01"; }
                    }
                    else { message = "ERROR: Latitude Must be between 29.5000 and 33.5000"; }
                }
                else { message = "ERROR: Longitude Must be between 34.0000 and 36.0000"; }
            }
            else { message = "ERROR: Description Cannot be null/empty, must be 10-500 characters"; }
            return ValidationResult.Failure(message);
            //Validates common fields for all report types:
            //- Timestamp: Cannot be in the future, cannot be before 2020 - 01 - 01
            //- Latitude: Must be between 29.5000 and 33.5000
            //- Longitude: Must be between 34.0000 and 36.0000
            //- Description: Cannot be null / empty, must be 10-500 characters
            //Returns ValidationResult.Failure(message) if any validation fails, otherwise
            //ValidationResult.Success().
        }
        protected abstract ValidationResult ValidateSpecificFields(Report report)
        {
            //Abstract method that derived validators must implement to validate type-specific fields.
        }
    }

}