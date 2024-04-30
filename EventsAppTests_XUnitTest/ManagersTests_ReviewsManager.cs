using EventsApp.Logic.Entities;
using EventsApp.Logic.Managers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppTests_XUnitTest
{
    public class ManagersTests_ReviewsManager
    {
        [Fact]
        public void GetReview_NoDBConnection_ReturnsReviewInfo()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid ReviewId = Guid.NewGuid();
            Guid EventId = Guid.NewGuid();

            ReviewInfo Expected = new ReviewInfo(Guid.Empty, Guid.Empty);

            // Act
            ReviewInfo actual = ReviewsManager.GetReview(ReviewId, EventId);

            Assert.Equal(Expected.EventGUID, actual.EventGUID);
            Assert.Null(actual.ReviewDescription);
        }

        [Fact]
        public void GetAllReviews_NoDBConnection_ReturnsEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            List<ReviewInfo> expected = new List<ReviewInfo>();

            // Act
            List<ReviewInfo> actual = ReviewsManager.GetAllReviews();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddReview_NoDBConnection_ResultsInEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid reviewerId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            float score = 0;
            string description = "Test";
            ReviewInfo Expected = new ReviewInfo(Guid.Empty, Guid.Empty, 0, string.Empty);
            // Act
            ReviewsManager.AddReview(reviewerId, eventId, score, description);
            ReviewInfo actual = ReviewsManager.GetReview(reviewerId, eventId);

            // Assert
            Assert.Equal(Expected.EventGUID, actual.EventGUID);
            Assert.Null(actual.ReviewDescription);
        }

        [Fact]
        public void GetAllReviewsOfReviewer_NoDBConnection_ReturnsEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid reviewerId = Guid.NewGuid();
            List<ReviewInfo> expected = new List<ReviewInfo>();

            // Act
            List<ReviewInfo> actual = ReviewsManager.GetAllReviewsOfReviewer(reviewerId);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAllReviewsOfEvent_NoDBConnection_ReturnsEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid eventId = Guid.NewGuid();
            List<ReviewInfo> expected = new List<ReviewInfo>();

            // Act
            List<ReviewInfo> actual = ReviewsManager.GetAllReviewsOfEvent(eventId);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAllReviewsOfUser_NoDBConnection_ReturnsEmptyList()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            List<ReviewInfo> expected = new List<ReviewInfo>();

            // Act
            List<ReviewInfo> actual = ReviewsManager.GetAllReviewsOfUser(userId);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetReviewsAverageScoreOfUser_NoDBConnection_ReturnsZero()
        {
            // Arrange
            ManagersInitializer.Initialize();
            Guid userId = Guid.NewGuid();
            // 0 users results in a devision by 0
            float expected = float.NaN;

            // Act
            float actual = ReviewsManager.GetReviewsAverageScoreOfUser(userId);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
