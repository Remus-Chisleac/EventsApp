using EventsApp.Logic.Entities;
using EventsApp.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppTests_XUnitTest
{
    public class ManagersTests_ReportsManager
    {
        [Fact]
        public void GetAllReports_NoDBConnection_ReturnsEmptyList()
        {

            // Arrange
            ManagersInitializer.Initialize();
            List<ReportInfo> expected = new List<ReportInfo>();

            // Act
            List<ReportInfo> actual = ReportsManager.GetAllReports();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetReport_NoDBConnection_ReturnsNull()
        {
            // Expected result
            Guid Expected_UserId = Guid.Empty;
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();

            // Act
            ReportInfo actual = ReportsManager.GetReport(userId, eventId);

            // Assert
            Assert.Equal(Expected_UserId, actual.UserGUID);
        }

        [Fact]
        public void GetReportsFromUser_NoDBConnection_ReturnsEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            List<ReportInfo> expected = new List<ReportInfo>();

            // Act
            List<ReportInfo> actual = ReportsManager.GetReportsFromUser(userId);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetReportsForEvent_NoDBConnection_ReturnsEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid eventId = Guid.NewGuid();
            List<ReportInfo> expected = new List<ReportInfo>();

            // Act
            List<ReportInfo> actual = ReportsManager.GetReportsForEvent(eventId);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddReport_NoDBConnection_ResultsInEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            ReportInfo.ReportType reportType = ReportInfo.ReportType.Spam;
            List<ReportInfo> expected = new List<ReportInfo>();

            // Act
            ReportsManager.AddReport(userId, eventId, reportType);
            List<ReportInfo> actual = ReportsManager.GetAllReports();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveReport_NoDBConnection_ResultsInEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            ReportInfo.ReportType reportType = ReportInfo.ReportType.Spam;
            List<ReportInfo> expected = new List<ReportInfo>();

            // Act
            ReportsManager.AddReport(userId, eventId, reportType);
            ReportsManager.RemoveReport(userId, eventId);
            List<ReportInfo> actual = ReportsManager.GetAllReports();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveAllReportsForEvent_NoDBConnection_ResultsInEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            ReportInfo.ReportType reportType = ReportInfo.ReportType.Spam;
            List<ReportInfo> expected = new List<ReportInfo>();

            // Act
            ReportsManager.AddReport(userId, eventId, reportType);
            ReportsManager.RemoveAllReportsForEvent(eventId);
            List<ReportInfo> actual = ReportsManager.GetAllReports();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveAllReportsFromUser_NoDBConnection_ResultsInEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            ReportInfo.ReportType reportType = ReportInfo.ReportType.Spam;
            List<ReportInfo> expected = new List<ReportInfo>();

            // Act
            ReportsManager.AddReport(userId, eventId, reportType);
            ReportsManager.RemoveAllReportsFromUser(userId);
            List<ReportInfo> actual = ReportsManager.GetAllReports();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveAllReports_NoDBConnection_ResultsInEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            ReportInfo.ReportType reportType = ReportInfo.ReportType.Spam;
            List<ReportInfo> expected = new List<ReportInfo>();

            // Act
            ReportsManager.AddReport(userId, eventId, reportType);
            ReportsManager.RemoveAllReports();
            List<ReportInfo> actual = ReportsManager.GetAllReports();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveAllReportsForEventAndUser_NoDBConnection_ResultsInEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            ReportInfo.ReportType reportType = ReportInfo.ReportType.Spam;
            List<ReportInfo> expected = new List<ReportInfo>();

            // Act
            ReportsManager.AddReport(userId, eventId, reportType);
            ReportsManager.RemoveAllReportsForEventAndUser(userId, eventId);
            List<ReportInfo> actual = ReportsManager.GetAllReports();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
