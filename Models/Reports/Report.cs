using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Models.Reports
{
    abstract class Report
    {
        public int ReportId { get; protected set; }
        public DateTime Timestamp { get; protected set; }
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }
        public string Description { get; protected set; }
        public ReportStatus Status { get; set; }
        public Priority Priority { get; set; }
        public Classification Classification { get; set; }
        public int ReliabilityScore { get; set; }
        public string RejectionReason { get; set; }

        protected Report(int reportId, DateTime timestamp, double latitude, double longitude, string description)
        {
            ReportId = reportId;
            Timestamp = timestamp;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Status = new ReportStatus();//?
            Priority = new Priority();//?
            Classification = new Classification();//?
            ReliabilityScore = new int();//?
            RejectionReason = "";//?
        }
        public abstract string GetSourceType();
        public abstract int CalculateReliabilityScore();
        public virtual string GetSummary()
        {
            return "";//?
        }
        public override string ToString()
        {
            return ""; //?
        }

    }
}