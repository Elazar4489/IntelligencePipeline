using IntelligencePipeline.Models.Enums;
using System.ComponentModel;
using System.Reflection;

namespace IntelligencePipeline.Models.Reports
{
    class SignalReport : Report
    {
        public double Frequency { get; protected set; }
        public string Content { get; protected set; }
        public Language Language { get; protected set; }
        public int SignalStrength { get; protected set; }

        public SignalReport(
            int reportId, DateTime timestamp, double latitude,
            double longitude, string description, double frequency,
            string content, Language language,int signalStrength)
            : base(reportId, timestamp, latitude, longitude, description)
        {
            Frequency = frequency;
            Content = content;
            Language = language;
            SignalStrength = signalStrength;
        }
        public override string GetSourceType() => "Signal";
        public override int CalculateReliabilityScore()
        {
//            mplements signal-specific reliability calculation:
//-Base: 5
//- SignalStrength >= -40: +3
//- SignalStrength >= -70: +2
//- Content contains attack/ target / border / vehicle: +1
//- SignalStrength < -100: -2
//- Result clamped to 1–10

            return 1;
        }

    }
}