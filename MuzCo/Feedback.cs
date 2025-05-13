using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MuzCo
{
    public class Feedback:IFeedback
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string TextMessage { get; set; }
        public DateTime ReviewDate { get; set; }

        private string reviewFile = "C:\\Users\\muzal\\source\\repos\\MuzCo\\MuzCoWPF\\MuzCoWPF\\Resources\\reviews.json";
        public static event Action<string> OnReviewsPlaced;

        public Feedback()
        {

        }

        public Feedback(string orderId, string userId, string textMessage, DateTime reviewDate)
        {
            //if (string.IsNullOrWhiteSpace(textMessage))
            //{
            //    throw new ArgumentException("TextMessage cannot be empty.", nameof(textMessage));
            //}
            this.OrderId = orderId;
            this.UserId = userId;
            this.TextMessage = textMessage;
            this.ReviewDate = reviewDate;
        }
        public List<Feedback> LoadReviews()
        {
            if (!File.Exists(reviewFile))
                return new List<Feedback>();

            string json = File.ReadAllText(reviewFile, Encoding.UTF8);
            return JsonConvert.DeserializeObject<List<Feedback>>(json) ?? new List<Feedback>();
        }

        private void SaveReviews(List<Feedback> reviews)
        {
            string json = JsonConvert.SerializeObject(reviews, Formatting.Indented);
            File.WriteAllText(reviewFile, json, Encoding.UTF8);
        }

        public void AddReview()
        {
            var reviews = LoadReviews();
            reviews.Add(this);
            SaveReviews(reviews);

            OnReviewsPlaced?.Invoke($"Новий відгук від {UserId} о замовленні {OrderId}");
          
        }
        public List<Feedback> GetReviewsByUser(string userId)
        {
            return new Feedback("", "", "", DateTime.Now).LoadReviews().Where(r => r.UserId == userId).ToList();
        }
       
        public string ToString()
        {
            return $"Order ID: {OrderId}\nUser ID: {UserId}\nВідгук: {TextMessage}\nДата: {ReviewDate}\n";
        }
    }
}
