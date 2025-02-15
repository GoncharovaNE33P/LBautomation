using LBautomation;

namespace TestForCalculator
{
    [TestClass]
    public sealed class TestSimple
    {
        [TestMethod]
        public void TestMethodForAddition_IsTrue()
        {
            List<double> list = new List<double> { 1.5, 2.5, 3 };

            double? result = LBautomation.Program.Addition(list);

            Assert.IsTrue(result == 7.0);
        }

        [TestMethod]
        public void TestMethodForAddition_IsFalse()
        {
            List<double> list = new List<double> { 1.5, 2.5, 3 };

            double? result = LBautomation.Program.Addition(list);

            Assert.IsFalse(result == 10.0);
        }

        [TestMethod]
        public void TestMethodForSubtraction_IsInstanceOfType()
        {
            List<double> list = new List<double> { 10, 5 };

            double? result = LBautomation.Program.Subtraction(list);

            Assert.IsInstanceOfType<double>(result);
        }

        [TestMethod]
        public void TestMethodForMultiplication_IsNotInstanceOfType()
        {
            List<double> list = new List<double> { 2, 3 };

            double? result = LBautomation.Program.Multiplication(list);

            Assert.IsNotInstanceOfType<int>(result);
        }

        [TestMethod]
        public void TestMethodForSin_IsNull()
        {
            List<double>? list = null;

            List<double>? result = LBautomation.Program.Sin(list);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestMethodForCtg_IsNotNull()
        {
            List<double> list = new List<double> { 0.5, 1, 1.5 };

            List<double>? result = LBautomation.Program.Ctg(list);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethodForExponentiation_AreEqual()
        {
            List<double> list = new List<double> { 2, 3 };

            double result = LBautomation.Program.Exponentiation(list);

            Assert.AreEqual(8.0, result);
        }

        [TestMethod]
        public void TestMethodForRootExtraction_AreEqual()
        {
            List<double> list = new List<double> { 4, 9 };

            List<double> result = LBautomation.Program.RootExtraction(list);

            List<double> expected = new List<double> { 2.0, 3.0 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethodForPercentageNumber_AreNotEqual()
        {
            List<double> list = new List<double> { 200, 10 };

            double? result = LBautomation.Program.PercentageNumber(list);

            Assert.AreNotEqual(50, result);
        }

        [TestMethod]
        public void TestMethodForLogarithm_AreNotEqual()
        {
            List<double> list = new List<double> { 8, 2 };

            double? result = LBautomation.Program.Logarithm(list);

            Assert.AreNotEqual(5, result);
        }

    }
    [TestClass]
    public sealed class TestHard
    {
        [TestMethod]
        public void TestMethodForDivision_DivisionByZero_ThrowsDivideByZeroException()
        {
            List<double> list = new List<double>() { 8, 0 };
            Assert.ThrowsException<LBautomation.DivideByZeroException>(() => { LBautomation.Program.Division(list); });
        }

        [TestMethod]
        public void TestMethodForCheckNumberItem_InputNegative1_ThrowsInvalidInputException()
        {
            int NumberItem = 11;
            Assert.ThrowsException<LBautomation.InvalidInputException>(() => { LBautomation.Program.CheckNumberItem(NumberItem); });
        }

        [TestMethod]
        public void TestMethodForExponentiation_InputNegative2_ThrowsInvalidInputException()
        {
            List<double> list = new List<double>() { 0, 5 };
            Assert.ThrowsException<LBautomation.InvalidInputException>(() => { LBautomation.Program.Exponentiation(list); });
        }

        [TestMethod]
        public void TestMethodForRootExtraction_InputNegative3_ThrowsInvalidInputException()
        {
            List<double> list = new List<double>() { 4, 16, -81 };
            Assert.ThrowsException<LBautomation.InvalidInputException>(() => { LBautomation.Program.RootExtraction(list); });
        }

        [TestMethod]
        public void TestMethodForLogarithm_InputNegative4_ThrowsInvalidInputException()
        {
            List<double> list = new List<double>() { 5, 1 };
            Assert.ThrowsException<LBautomation.InvalidInputException>(() => { LBautomation.Program.Logarithm(list); });
        }
    }
}
