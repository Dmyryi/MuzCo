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
            var user = new Customer("e0f1207c-fdc2-4e08-bd86-f54075f60016", "Dom", "qwerty", UserRole.Customer);

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
            var user = new Admin("e0f1207c-fdc2-4e08-bd86-f54075f60016", "AdminUser", "adminpass", UserRole.Admin);

            // Assert
            Assert.AreEqual("e0f1207c-fdc2-4e08-bd86-f54075f60016", user.Id);
            Assert.AreEqual("AdminUser", user.UserName);
            Assert.AreEqual("adminpass", user.Password);
        
        }
    }

    [TestClass]
    public class FeedbackTests
    {
        [TestMethod]
        public void Feedback_Constructor_ShouldSetProperties()
        {
            // Arrange
            DateTime date = DateTime.Now;

            // Act
            var feedback = new Feedback("order123", "user456", "Great pizza!", date);

            // Assert
            Assert.AreEqual("order123", feedback.OrderId);
            Assert.AreEqual("user456", feedback.UserId);
            Assert.AreEqual("Great pizza!", feedback.TextMessage);
       
        }

        [TestMethod]
        public void Feedback_Constructor_EmptyMessage_ShouldThrowException()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Feedback("order123", "user456", "", DateTime.Now));
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
            var status = "Готується";

            // Act
            var order = new Order("user456", pizzas, totalPrice, status);

            // Assert
            Assert.AreEqual("user456", order.UserId);
            CollectionAssert.AreEqual(pizzas, order.Pizzas);
            Assert.AreEqual(totalPrice, order.TotalPrice);
        }

        [TestMethod]
        public void Order_Constructor_EmptyPizzas_ShouldThrowException()
        {
            // Arrange
            string userId = "user456";
            var emptyPizzas = new List<string>();
            double totalPrice = 25.99;
            string status = "Готується";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new Order(userId, emptyPizzas, totalPrice, status));
        }

        [TestMethod]
        public void Order_Constructor_EmptyStatus_ShouldThrowException()
        {
            // Arrange
            string userId = "user456";
            var pizzas = new List<string> { "Margherita", "Pepperoni" };
            double totalPrice = 25.99;
            string emptyStatus = "";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new Order(userId, pizzas, totalPrice, emptyStatus));
        }


        [TestMethod]
        public void Order_GetOrderHistory_NonExistentUser_ShouldReturnEmpty()
        {
            // Arrange
            var order = new Order("user456", new List<string> { "Margherita" }, 25.99, "Готується");

            //Act
           var history = Order.GetOrderHistory("nonExistentUser");

            //Assert
            Assert.AreEqual(0, history.Count);
        }
    }
}
