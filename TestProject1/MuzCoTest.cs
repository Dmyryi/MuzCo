using MuzCo;

namespace TestMuzCo
{

    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void User_ConstructorCustomer_ShouldSetProperties()
        {
            // Arrange & Act
            var user = new Customer("e0f1207c-fdc2-4e08-bd86-f54075f60016", "Dom", "qwerty");

            // Assert
            Assert.AreEqual("e0f1207c-fdc2-4e08-bd86-f54075f60016", user.Id);
            Assert.AreEqual("Dom", user.UserName);
            Assert.AreEqual("qwerty", user.Password);
            Assert.AreEqual(UserRole.Customer, user.UserRole);
        }

        [TestMethod]
        public void User_ConstructorAdmin_ShouldSetProperties()
        {
            // Arrange & Act
            var user = new Admin("e0f1207c-fdc2-4e08-bd86-f54075f60016", "Dom", "qwerty");

            // Assert
            Assert.AreEqual("e0f1207c-fdc2-4e08-bd86-f54075f60016", user.Id);
            Assert.AreEqual("Dom", user.UserName);
            Assert.AreEqual("qwerty", user.Password);
            Assert.AreEqual(UserRole.Admin, user.UserRole);
        }

        [TestMethod]
        public void User_DeleteORderAdmin()
        {
            // Arrange & Act
            var user = new Admin("e0f1207c-fdc2-4e08-bd86-f54075f60016", "Dom", "qwerty");
            user.DeleteOrder();
 
        }

        [TestMethod]
        public void User_AddnewPizzaAdmin()
        {
            // Arrange & Act
            var user = new Admin("e0f1207c-fdc2-4e08-bd86-f54075f60016", "Dom", "qwerty");
            user.AddNewPizza();

        }

      
    }

    [TestClass]
    public class FeedbackTests
    {
        [TestMethod]
        public void Feedback_Constructor_ShouldSetProperties()
        {
            // Arrange
            var date = DateTime.Now;

            // Act
            var feedback = new Feedback("order123", "user456", "Great pizza!", date);

            // Assert
            Assert.AreEqual("order123", feedback.OrderId);
            Assert.AreEqual("user456", feedback.UserId);
            Assert.AreEqual("Great pizza!", feedback.TextMessage);
            Assert.AreEqual(date, feedback.ReviewDate);
        }
        [TestMethod]
        public void Feedback_AddReview()
        {
            // Arrange
            var date = DateTime.Now;

            // Act
            var feedback = new Feedback("order123", "user456", "Great pizza!", date);
            feedback.AddReview();
        }
        [TestMethod]
        public void Feedback_GetReviewsByUser()
        {
            // Arrange
            DateTime date = DateTime.Now;
            string userId = "user456";
            // Act
            var feedback = new Feedback("order123", userId, "Great pizza!", date);
            feedback.GetReviewsByUser(userId);
        }
        [TestMethod]
        public void Feedback_GetReviewsByOrder()
        {
            // Arrange
            DateTime date = DateTime.Now;
            string orderId = "order456";
            // Act
            var feedback = new Feedback(orderId, "user456", "Great pizza!", date);
            feedback.GetReviewsByOrder(orderId);
        }
    }

    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Order_Constructor_ShouldSetProperties()
        {
            // Arrange
            var pizzas = new List<string> { "Margherita", "Pepperoni" };
            var totalPrice = 25.99;
            var orderDate = DateTime.Now;

            // Act
            var order = new Order("user456", pizzas, totalPrice);

            // Assert
            Assert.AreEqual("user456", order.UserId);
            CollectionAssert.AreEqual(pizzas, order.Pizzas);
            Assert.AreEqual(totalPrice, order.TotalPrice);
        }

        public void Order_Constructor()
        {
            // Arrange
            var pizzas = new List<string> { "Margherita", "Pepperoni" };
            var totalPrice = 25.99;
            var orderDate = DateTime.Now;

            // Act
            var order = new Order();

            // Assert
            Assert.AreEqual("user456", order.UserId);
            CollectionAssert.AreEqual(pizzas, order.Pizzas);
            Assert.AreEqual(totalPrice, order.TotalPrice);
        }

        

        [TestMethod]
        public void GetOrderHistory_ShouldThrowNotImplementedException()
        {
            var pizzas = new List<string> { "Margherita", "Pepperoni" };
            var totalPrice = 25.99;
            var orderDate = DateTime.Now;
            string id = "user456";
            // Arrange
            var order = new Order(id, pizzas, totalPrice);
            order.GetOrderHistory(id);

        }

 
    }
}

