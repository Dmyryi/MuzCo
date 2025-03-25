using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MuzCo
{
    class Feedback
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string TextMessage { get; set; }
        public DateTime ReviewDate { get; set; }

        public List<Feedback> LoadFeedback()
        {
            throw new ArgumentException("Invalid filePath");
        }

        private void SaveReviews(List<Feedback> reviews)
        {
            throw new ArgumentException("Invalid reviews", nameof(reviews));
        }

        public void AddReview()
        {
            throw new ArgumentException("Invalid filePath");
        }
        public static List<Feedback> GetReviewsByUser(string userId)
        {
            throw new ArgumentException("Invalid userId", nameof(userId));
        }
        public static List<Feedback> GetReviewsByOrder(string orderId)
        {
            throw new ArgumentException("Invalid orderId", nameof(orderId));
        }
    }
}
