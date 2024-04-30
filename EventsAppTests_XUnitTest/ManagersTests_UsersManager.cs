using EventsApp.Logic.Entities;
using EventsApp.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppTests_XUnitTest
{
    public class ManagersTests_UsersManager
    {
        [Fact]
        public void GetUser_WithNoDBConnection_ReturnsDefaultUser()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid expected = Guid.Empty;

            // Act
            UserInfo actual = UsersManager.GetUser(userId);

            // Assert
            Assert.Equal(expected, actual.GUID);
        }

        [Fact]
        public void GetAllUsers_WithNoDBConnection_ReturnsEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            List<UserInfo> expected = new List<UserInfo>();

            // Act
            List<UserInfo> actual = UsersManager.GetAllUsers();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsAdmin_WithNoDBConnection_ReturnsFalse()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            bool expected = false;

            // Act
            bool actual = UsersManager.IsAdmin(userId);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HasPermission_WithNoDBConnection_ReturnsZeroFloat()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            float expected = 0;

            // Act
            float actual = UsersManager.HasPermission(userId);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SearchUsersByUsername_WithNoDBConnection_ReturnsEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            string username = "Test";
            List<UserInfo> expected = new List<UserInfo>();

            // Act
            List<UserInfo> actual = UsersManager.SearchUsersByUsername(username);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddNewUser_WithNoDBConnection_ResultsInEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            string name = "Test";
            string password = "Test";
            List<UserInfo> expected = new List<UserInfo>();

            // Act
            UsersManager.AddNewUser(name, password);
            List<UserInfo> actual = UsersManager.GetAllUsers();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetInterestedStatus_WithNoDBConnection_ResultsInEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            List<UserInfo> expected = new List<UserInfo>();

            // Act
            UsersManager.SetInterestedStatus(userId, eventId);
            List<UserInfo> actual = UsersManager.GetAllUsers();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetGoingStatus_WithNoDBConnection_ResultsInEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            List<UserInfo> expected = new List<UserInfo>();

            // Act
            UsersManager.SetGoingStatus(userId, eventId);
            List<UserInfo> actual = UsersManager.GetAllUsers();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveInterestedStatus_WithNoDBConnection_ResultsInEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            List<UserInfo> expected = new List<UserInfo>();

            // Act
            UsersManager.RemoveInterestedStatus(userId, eventId);
            List<UserInfo> actual = UsersManager.GetAllUsers();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsInterested_WithNoDBConnection_ReturnsFalse()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            bool expected = false;

            // Act
            bool actual = UsersManager.IsInterested(userId, eventId);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsGoing_WithNoDBConnection_ReturnsFalse()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            bool expected = false;

            // Act
            bool actual = UsersManager.IsGoing(userId, eventId);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
