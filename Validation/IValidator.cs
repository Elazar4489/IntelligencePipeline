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
//            Template method that validates both common and specific fields:
//            1.Calls ValidateCommonFields(report) - validates shared fields
//            2.If common validation passes, calls ValidateSpecificFields(report) -validates
//type - specific fields
//3.Returns ValidationResult indicating success or failure
        }
        protected ValidationResult ValidateCommonFields(Report report)
        {
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