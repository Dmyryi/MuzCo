using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MuzCo
{
    public class Feedback
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string TextMessage { get; set; }
        public DateTime ReviewDate { get; set; }


        public Feedback(string orderId, string userId, string textMessage, DateTime reviewDate)
        {
            throw new NotImplementedException();
        }

        private List<Feedback> LoadFeedback()
        {
            throw new NotImplementedException();
        }

        private void SaveReviews(List<Feedback> reviews)
        {
            throw new NotImplementedException();
        }

        public void AddReview()
        {
            throw new NotImplementedException();
        }
        public List<Feedback> GetReviewsByUser(string userId)
        {
            throw new NotImplementedException();
        }
        public List<Feedback> GetReviewsByOrder(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
