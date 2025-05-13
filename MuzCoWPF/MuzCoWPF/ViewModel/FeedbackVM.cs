using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCo;
using MuzCoWPF.Utilities;

namespace MuzCoWPF.ViewModel
{
    public class FeedbackVM:ViewModelBase
    {
        public ObservableCollection<FeedbackItemVM> Feedbacks { get; }
        public Customer Customer { get; }

        public Feedback feedback;
        public FeedbackVM(string userId)
        {
            feedback = new Feedback();
            var feedbacks = feedback.GetReviewsByUser(userId);
            foreach (var f in feedbacks)
            {
                Debug.WriteLine($"Feedback от {f.UserId}, текст: {f.TextMessage ?? "[null]"}");
            }
            Feedbacks = new ObservableCollection<FeedbackItemVM>(feedbacks.Select(o => new FeedbackItemVM(o)));
        }


    }
}
