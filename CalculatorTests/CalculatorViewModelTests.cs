using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator.Core;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorViewModelTests
    {
        [TestMethod]
        public void AddCommand_ValidInput_ReturnsCorrectResult()
        {
            // Arrange
            var vm = new CalculatorViewModel { Number1 = "10", Number2 = "7" };

            // Act
            vm.AddCommand.Execute(null);

            // Assert
            Assert.AreEqual("17", vm.Result);
        }

        [TestMethod]
        public void DivideCommand_DivideByZero_ReturnsErrorMessage()
        {
            // Arrange
            var vm = new CalculatorViewModel { Number1 = "5", Number2 = "0" };

            // Act
            vm.DivideCommand.Execute(null);

            // Assert
            Assert.AreEqual("Cannot divide by zero", vm.Result);
        }

        [TestMethod]
        public void MultiplyCommand_ValidInput_ReturnsCorrectResult()
        {
            var vm = new CalculatorViewModel { Number1 = "4", Number2 = "5" };
            vm.MultiplyCommand.Execute(null);
            Assert.AreEqual("20", vm.Result);
        }

        [TestMethod]
        public void SubtractCommand_InvalidInput_ReturnsInvalidInput()
        {
            var vm = new CalculatorViewModel { Number1 = "abc", Number2 = "2" };
            vm.SubtractCommand.Execute(null);
            Assert.AreEqual("Invalid input", vm.Result);
        }
    }
}
