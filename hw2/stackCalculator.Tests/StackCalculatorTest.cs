using NUnit.Framework;
using StackCalculator;
using System.Collections.Generic;
using System;

namespace stackCalculator.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static IEnumerable<string> StackTypesToTest
        {
            get
            {
                yield return "0";
                yield return "1";
            }
        }

        private const double epsilon = 1e-7;

        /// <summary>
        /// Проверка работы каждой операции на корректных тестах
        /// </summary>
        [Test, TestCaseSource(nameof(StackTypesToTest))]
        public void EachCorrectOperationWorksCorrectlyTest(string type)
        {
            Assert.IsTrue(Calculator.Calculation("132", type) - 132 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("-12", type) + 12 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("1 2 45 * - 14 + 2 - 3 /", type) + 25.66666 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("20 17 - 34 59 * + 74 - 1 130 / + 81 +", type) 
                - 2016.0076923 <= epsilon);
        }

        /// <summary>
        /// Проверка работы с выражениями, содержащими 0
        /// </summary>
        [Test, TestCaseSource(nameof(StackTypesToTest))]
        public void ExpressionsWithZeroTest(string type)
        {
            Assert.IsTrue(Calculator.Calculation("5 0 +", type) - 5 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("0 47 +", type) - 47 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("0 2 -", type) + 2 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("4 0 -", type) - 4 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("4 0 *", type) + 0 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("0 -5 *", type) + 0 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("0 6 /", type) + 0 <= epsilon);
        }

        /// <summary>
        /// Проверка появления ошибки при делении на 0
        /// </summary>
        [Test, TestCaseSource(nameof(StackTypesToTest))]
        public void ExceptionInDivisionByZeroTest(string type)
        {
            Assert.Throws<InvalidOperationException>(() => { Calculator.Calculation("34 9287 + 123 4 * - 0 /", type); });
        }

        /// <summary>
        /// Проверка работы с отрицательными числами
        /// </summary>
        [Test, TestCaseSource(nameof(StackTypesToTest))]
        public void NegativeNumbersInStackTest(string type)
        {
            Assert.IsTrue(Calculator.Calculation("-5 -4 +", type) + 1 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("-1 -17 -", type) - 16 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("-6 -3 *", type) - 18 <= epsilon);
            Assert.IsTrue(Calculator.Calculation("-1024 -2 -", type) - 512 <= epsilon);
        }

        /// <summary>
        /// Проверка появления ошибки при вводе некорректных данных
        /// </summary>
        [Test, TestCaseSource(nameof(StackTypesToTest))]
        public void ExceptionInIncorrectInputDataTest(string type)
        {
            Assert.Throws<InvalidOperationException>(() => { Calculator.Calculation("5 45647", type); });
            Assert.Throws<InvalidOperationException>(() => { Calculator.Calculation("5 45647 - +", type); });
            Assert.Throws<ArgumentNullException>(() => { Calculator.Calculation("", type); });
            Assert.Throws<InvalidOperationException>(() => { Calculator.Calculation("ww vfd +", type); });
            Assert.Throws<InvalidOperationException>(() => { Calculator.Calculation("/", type); });
            Assert.Throws<InvalidOperationException>(() => { Calculator.Calculation("1 * 2", type); });
        }
    }
}