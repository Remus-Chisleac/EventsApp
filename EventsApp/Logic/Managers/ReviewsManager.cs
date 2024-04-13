using EventsApp.Logic.Adapters;
using EventsApp.Logic.Entities;
using EventsApp.Logic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Managers
{
    public static class ReviewsManager
    {
        private static DataAdapter<ReviewInfo> _adapter;

        public static void Initialize(DataAdapter<ReviewInfo> adapter)
        {
            _adapter = adapter;
        }

        public static ReviewInfo GetReview(Guid reviewerId, Guid eventId)
        {
            ReviewInfo review = new ReviewInfo(reviewerId, eventId);
            return _adapter.Get(review.GetIdentifier());
        }

        public static List<ReviewInfo> GetAllReviews()
        {
            return _adapter.GetAll();
        }

        public static void AddReview(Guid reviewerId, Guid eventId, float score, string description)
        {
            ReviewInfo review = new ReviewInfo(reviewerId, eventId, score, description);

            _adapter.Add(review);
        }

        public static List<ReviewInfo> GetAllReviewsOfReviewer(Guid reviewer)
        {
            // TODO: ReviewsManager: Implement this method
            return null;
        }

        public static List<ReviewInfo> GetAllReviewsOfEvent(Guid eventId)
        {
            // TODO: ReviewsManager: Implement this method
            return null;
        }

        public static List<ReviewInfo> GetAllReviewsOfUser(Guid userId)
        {
            // TODO: ReviewsManager: Implement this method
            return null;
        }

        /// <summary>
        /// Mean value of all reviews of a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static float GetScoreOfUser(Guid userId)
        {
            // TODO: ReviewsManager: Implement this method
            return 0;
        }
    }
}
