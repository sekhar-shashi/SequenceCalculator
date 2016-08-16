using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceCalculator;
using SequenceCalculator.Controllers;



namespace SequenceCalculator.Tests.Controllers
{
    [TestClass]
    public class NumericSequenceControllerTest
    {
        [TestMethod]
        public void Sequence()
        {
            // Arrange
            NumericSequenceController controller = new NumericSequenceController();

            // Act
            ViewResult result = controller.Sequence() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void test()
        {
            
            NumericSequenceController controller = new NumericSequenceController();
            SequenceCalculator.Models.SequenceModel m = new Models.SequenceModel();
            // setting up Mock data as input
            m.InputNumber = 4;
            List<int> allvalues = new List<int>(new int[] {0, 1, 2, 3,4 });
            List<int> alleven = new List<int>(new int[] { 2, 4 });
            // Act
            ViewResult result = controller.Sequence(m) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            //comparing against mock data if equal than pass else fail
            CollectionAssert.AreEqual(m.AllNumber, allvalues);
            //Assert.AreEqual(, allvalues);
            CollectionAssert.AreEqual(m.AllEven, alleven);
            Assert.IsNotNull(result.Model);

            // checking modal is valid or not

        }
    }
}
