using IntelligencePipeline.Calculators;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;

namespace IntelligencePipeline.Pipeline
{
    class ReportPipeline
    {
        private ReportRepository _validatedReports;
        private RejectedReportRepository _rejectedReports;
        private int _nextReportId;
        public ReportPipeline()
        {
            _validatedReports = new ReportRepository();
            _rejectedReports = new RejectedReportRepository();
            _nextReportId = 0;
        }
        public void ProcessReport(Report report)
        {
            report.ReportId = _nextReportId;
            _nextReportId++;
            report.Status = ReportStatus.Validating;
            ValidateReport(report);
            if (report.Status == ReportStatus.Validated){CalculateMetrics(report);}
            StoreReport(report);
        }
        public ReportRepository GetValidatedReports()
        {
            return _validatedReports;
        }
        public RejectedReportRepository GetRejectedReports()
        {
            return _rejectedReports;
        }
        public void DisplayStatistics() { }
        //מדפיסה את הסטטיסטיקות


        private IValidator GetValidator(Report report)
        {
            string theType = report.GetSourceType();
            IValidator? validator = null;
            return theType switch
            {
                "Drone" => new DroneValidator(),
                "Soldier" => new SoldierValidator(),
                "Radar" => new RadarValidator(),
                "Signal" => new SignalValidator(),
            };
        }
        private void ValidateReport(Report report)
        {
            IValidator validator = GetValidator(report);
            ValidationResult validationResult = validator.Validate(report);
            if (validationResult.IsValid)
            {
                report.Status = ReportStatus.Validated;
            }
            else
            {
                report.Status = ReportStatus.Rejected;
                report.RejectionReason = validationResult.ErrorMessage;
            }
        }
        private void CalculateMetrics(Report report)
        {
            PriorityCalculator priority = new PriorityCalculator();
            ReliabilityCalculator reliability = new ReliabilityCalculator();
            ClassificationCalculator classification = new ClassificationCalculator();
            priority.Calculate(report);
            reliability.Calculate(report);
            classification.Calculate(report);
        }
        private void StoreReport(Report report)
        {
            if (report.Status == ReportStatus.Rejected){_rejectedReports.Add(report);}
            else if (report.Status == ReportStatus.Validated) { _validatedReports.Add(report); }
        }

    }
}