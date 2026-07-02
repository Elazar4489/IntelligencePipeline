using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;

namespace IntelligencePipeline.Storage
{
    class ReportRepository
    {
        private List<Report> _reports;
        public ReportRepository()
        {
            _reports = new List<Report>();
        }
        public void Add(Report report)
        {
            _reports.Add(report);
        }
        public List<Report> GetAll()
        {
            return _reports;
        }
        public List<Report> GetByStatus(ReportStatus status)
        {
            List<Report> reports = new List<Report>();
            foreach (Report report in _reports)
            {
                if (report.Status == status)
                {
                    reports.Add(report);
                }
            }
            return reports;
        }
        public List<Report> GetByPriority(Priority priority)
        {
            List<Report> reports = new List<Report>();
            foreach (Report report in _reports)
            {
                if (report.Priority == priority)
                {
                    reports.Add(report);
                }
            }
            return reports;
        }
        public List<Report> Search(string keyword)
        {
            List<Report> matchingReports = new List<Report>();

            if (string.IsNullOrEmpty(keyword))
            {
                return matchingReports;
            }

            foreach (Report report in _reports)
            {
                if (report.Description != null)
                {
                    if (report.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        matchingReports.Add(report);
                    }
                }
            }

            return matchingReports;
        }        
        public Report? GetById(int reportId)
        {
            foreach (Report report in _reports)
            {
                if (report.ReportId == reportId)
                {
                    return report;
                }
            }
            return null;
        }
        public void UpdateStatus(int reportId, ReportStatus newStatus)
        {
            Report? report = GetById(reportId);
            if (report is not null)
            {
                report.Status = newStatus;
            }
        }
        public int GetTotalCount()
        {
            return _reports.Count;
        }
        public int GetCountByStatus(ReportStatus status)
        {
            List<Report> reports = GetByStatus(status);
            return reports.Count;
        }
    }
}