using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppTests_XUnitTest
{
    using EventsApp.Logic.Adapters;
    using EventsApp.Logic.Entities;
    using EventsApp.Logic.Managers;
    public class ManagersTests_DonationsManagers
    {
        private readonly string connectionString = "Server=tcp:iss-events.database.windows.net,1433;Initial Catalog=EventsDB;Persist Security Info=False;User ID={id};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        [Fact]
        public void GetDonation_NoDBConnetion_ReturnsDonationInfo()
        {
            //
            DonationInfo Expected_return = new DonationInfo(Guid.Empty);
            // Arrange
            Guid donationId = Guid.NewGuid();
            DonationInfo donationInfo = new DonationInfo(donationId);
            DonationsManager.Initialize(new DataBaseAdapter<DonationInfo>(connectionString));
            DonationsManager.AddDonation(donationInfo.UserGUID, donationInfo.EventGUID, donationInfo.Amount);

            // Act
            DonationInfo actual = DonationsManager.GetDonation(donationId);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void GetAll_NoDBConnetion_ReturnsDonationInfo()
        {
            // Arrange
            List<DonationInfo> Expected_return = new List<DonationInfo>();
            DonationsManager.Initialize(new DataBaseAdapter<DonationInfo>(connectionString));

            // Act
            List<DonationInfo> actual = DonationsManager.GetAllDonations();

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void GetAllDonationsForEvent_NoDBConnetion_ReturnsDonationInfo()
        {
            // Arrange
            List<DonationInfo> Expected_return = new List<DonationInfo>();
            Guid eventGUID = Guid.NewGuid();
            DonationsManager.Initialize(new DataBaseAdapter<DonationInfo>(connectionString));

            // Act
            List<DonationInfo> actual = DonationsManager.GetAllDonationsForEvent(eventGUID);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void AddDonation_NoDBConnetion_ReturnsDonationInfo()
        {
            // Expected return with no DB_Connection
            DonationInfo Expected_return = new DonationInfo(Guid.Empty);

            // Arrange
            Guid donationId = Guid.NewGuid();
            DonationInfo donationInfo = new DonationInfo(donationId);
            DonationsManager.Initialize(new DataBaseAdapter<DonationInfo>(connectionString));

            // Act
            DonationsManager.AddDonation(donationInfo.UserGUID, donationInfo.EventGUID, donationInfo.Amount);
            DonationInfo actual = DonationsManager.GetDonation(donationId);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void GetTotalDonationsForEvent_NoDBConnetion_ReturnsDonationInfo()
        {
            // Expected return with no DB_Connection
            float Expected_return = 0.0f;

            // Arrange
            Guid eventGUID = Guid.NewGuid();
            DonationsManager.Initialize(new DataBaseAdapter<DonationInfo>(connectionString));

            // Act
            float actual = DonationsManager.GetTotalDonationsForEvent(eventGUID);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void GetDonationsFromUser_NoDBConnetion_ReturnsDonationInfo()
        {
            // Expected return with no DB_Connection
            List<DonationInfo> Expected_return = new List<DonationInfo>();

            // Arrange
            Guid userGUID = Guid.NewGuid();
            DonationsManager.Initialize(new DataBaseAdapter<DonationInfo>(connectionString));

            // Act
            List<DonationInfo> actual = DonationsManager.GetDonationsFromUser(userGUID);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void RemoveDonation_NoDBConnetion_ReturnsDonationInfo()
        {
            // Expected return with no DB_Connection
            DonationInfo Expected_return = new DonationInfo(Guid.Empty);

            // Arrange
            Guid donationId = Guid.NewGuid();
            DonationInfo donationInfo = new DonationInfo(donationId);
            DonationsManager.Initialize(new DataBaseAdapter<DonationInfo>(connectionString));
            DonationsManager.AddDonation(donationInfo.UserGUID, donationInfo.EventGUID, donationInfo.Amount);

            // Act
            DonationsManager.RemoveDonation(donationId);
            DonationInfo actual = DonationsManager.GetDonation(donationId);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void RemoveAllDonationsForEvent_NoDBConnetion_ReturnsDonationInfo()
        {
            // Expected return with no DB_Connection
            List<DonationInfo> Expected_return = new List<DonationInfo>();

            // Arrange
            Guid eventGUID = Guid.NewGuid();
            DonationsManager.Initialize(new DataBaseAdapter<DonationInfo>(connectionString));

            // Act
            DonationsManager.RemoveAllDonationsForEvent(eventGUID);
            List<DonationInfo> actual = DonationsManager.GetAllDonationsForEvent(eventGUID);

            // Assert
            Assert.Equal(Expected_return, actual);
        }
    }
}
