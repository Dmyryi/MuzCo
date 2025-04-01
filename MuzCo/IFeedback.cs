using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
   public interface IFeedback
    {
        public void AddReview();
        public  List<Feedback> GetReviewsByUser(string userId);
    }
}
