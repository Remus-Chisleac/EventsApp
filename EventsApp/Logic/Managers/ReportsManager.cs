using EventsApp.Logic.Adapters;
using EventsApp.Logic.Attributes;
using EventsApp.Logic.Entities;
using EventsApp.Logic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Managers
{
    public class ReportsManager
    {
        private static DataAdapter<ReportInfo> _adapter;

        public static void Initialize(DataBaseAdapter<ReportInfo> adapter)
        {
            _adapter = adapter;
        }

        public static List<ReportInfo> GetAllReports()
        {
            return _adapter.GetAll();
        }

        public static ReportInfo GetReport(Guid userId, Guid eventId)
        {
            ReportInfo reportInfo = new ReportInfo(userId, eventId);
            return _adapter.Get(reportInfo.GetIdentifier());
        }

        public static List<ReportInfo> GetReportsFromUser(Guid userId)
        {
            List<ReportInfo> reportInfos = new List<ReportInfo>();
            foreach (ReportInfo report in GetAllReports())
            {
                if (report.userGUID == userId)
                {
                    reportInfos.Add(report);
                }
            }
            return reportInfos;
        }

        public static List<ReportInfo> GetReportsForEvent(Guid eventId)
        {
            List<ReportInfo> reportInfos = new List<ReportInfo>();
            foreach (ReportInfo report in GetAllReports())
            {
                if (report.eventGUID == eventId)
                {
                    reportInfos.Add(report);
                }
            }
            return reportInfos;
        }


        public static void AddReport(Guid reportId, Guid eventId, ReportInfo.ReportType reportType)
        {
            // TODO: ReportsManager: Implement this method
            ReportInfo reportInfo = new ReportInfo(reportId, eventId, reportType);
        }
    }
}
