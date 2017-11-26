using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnglishForKidAPI;
using EnglishForKidAPI.Controllers;
using System.Collections.Generic;
using EnglishForKidAPI.Models;
using System.Linq;

namespace EnglishForKidAPI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            FeedbacksController controller = new FeedbacksController();

            // Act
            List<Feedback> feedbacks = controller.GetFeedbacks().ToList();

            // Assert
            Assert.IsNotNull(feedbacks);
            //Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
