using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Storage
{
    class RejectedReportRepository
    {
        private List<Report> _rejectedReports;
        public RejectedReportRepository()
        {
            _rejectedReports = new List<Report>();
        }
        public void Add(Report report)
        {
            _rejectedReports.Add(report);
        }
        public List<Report> GetAll()
        {
            return _rejectedReports;
        }
        public int GetTotalCount()
        {
            return _rejectedReports.Count;
        }
        public List<Report> GetByReason(string reasonKeyword)
        {
            List<Report> matchingRejectReports = new List<Report>();

            if (string.IsNullOrEmpty(reasonKeyword))
            {
                return matchingRejectReports;
            }
            foreach (Report report in _rejectedReports)
            {
                if (report.RejectionReason != null)
                {
                    if (report.RejectionReason.Contains(reasonKeyword, StringComparison.OrdinalIgnoreCase))
                    {
                        matchingRejectReports.Add(report);
                    }
                }
            }
            return matchingRejectReports;
        }
    }
}