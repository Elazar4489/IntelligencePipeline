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

        }
        public ReportRepository GetValidatedReports() { }
        //מחזירה את רשימת הדוחות התקינים
        public RejectedReportRepository GetRejectedReports() { }
        //מחזירה את רשימת הדוחות הלא תקינים
        public void DisplayStatistics() { }
        //מדפיסה את הסטטיסטיקות


        private IValidator GetValidator(Report report) { }
        private void ValidateReport(Report report) { }
        private void CalculateMetrics(Report report) { }
        private void StoreReport(Report report) { }

    }
}