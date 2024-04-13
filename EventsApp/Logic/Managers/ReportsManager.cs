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

        public static ReportInfo GetReport(Guid reportId, Guid eventId)
        {
            ReportInfo reportInfo = new ReportInfo(reportId, eventId);
            return _adapter.Get(reportInfo.GetIdentifier());
        }

        public static List<ReportInfo> GetReportsFromUser(Guid userId)
        {
            // TODO: ReportsManager: Implement this method
            return null;
        }

        public static List<ReportInfo> GetReportsForEvent(Guid eventId)
        {
            // TODO: ReportsManager: Implement this method
            return null;
        }

        public static List<ReportInfo> GetAllReports()
        {
            return _adapter.GetAll();
        }

        public static void AddReport(Guid reportId, Guid eventId, ReportInfo.ReportType reportType)
        {
            // TODO: ReportsManager: Implement this method
            ReportInfo reportInfo = new ReportInfo(reportId, eventId, reportType);
        }
    }
}
