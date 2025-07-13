using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator.Core;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorViewModelTests
    {
        [TestMethod]
        public void AddCommand_ValidInput_ReturnsCorrectResult() //ทดสอบการทำงานของคำสั่งบวก (AddCommand) ว่าเมื่อกรอกเลขถูกต้อง ผลลัพธ์จะถูกต้องหรือไม่
        {
            var vm = new CalculatorViewModel { Number1 = "10", Number2 = "7" };
            vm.AddCommand.Execute(null);
            Assert.AreEqual("17", vm.Result);
        }

        [TestMethod]
        public void DivideCommand_DivideByZero_ReturnsErrorMessage()//ทดสอบการหารด้วยศูนย์ ว่าจะแสดงข้อความ Error ที่ถูกต้องหรือไม่
        {
            var vm = new CalculatorViewModel { Number1 = "5", Number2 = "0" };
            vm.DivideCommand.Execute(null);
            Assert.AreEqual("Cannot divide by zero", vm.Result);
        }

        [TestMethod]
        public void MultiplyCommand_ValidInput_ReturnsCorrectResult()//ทดสอบการคูณเลข เมื่อกรอกเลขถูกต้อง ผลลัพธ์ต้องถูกต้อง
        {
            var vm = new CalculatorViewModel { Number1 = "4", Number2 = "5" };
            vm.MultiplyCommand.Execute(null);
            Assert.AreEqual("20", vm.Result);
        }

        [TestMethod]
        public void SubtractCommand_InvalidInput_ReturnsInvalidInput()//ทดสอบกรณีที่กรอกค่าผิดพลาด เช่น กรอกตัวอักษร แทนตัวเลข ต้องแสดงข้อความแจ้งเตือน
        {
            var vm = new CalculatorViewModel { Number1 = "abc", Number2 = "2" };
            vm.SubtractCommand.Execute(null);
            Assert.AreEqual("Invalid input", vm.Result);
        }
    }
}
