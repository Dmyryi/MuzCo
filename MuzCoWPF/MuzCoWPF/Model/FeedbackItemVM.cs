using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCo;

namespace MuzCoWPF.ViewModel
{
   public class FeedbackItemVM
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string TextMessage { get; set; }
        public string ReviewDate { get; set; }

        public FeedbackItemVM(Feedback feedback)
        {
            OrderId = feedback.OrderId;
            UserId = feedback.UserId;
            TextMessage = feedback.TextMessage;
            ReviewDate = feedback.ReviewDate.ToString("dd.MM.yyyy HH:mm");
        }
    }
}
