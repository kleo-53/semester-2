namespace stackCalculator.Tests;

using NUnit.Framework;
using StackCalculator;
using System.Collections.Generic;
using System;

public class Tests
{
    private static IEnumerable<IStack> StackToTest
    {
        get
        {
            yield return new StackOnArray();
            yield return new StackOnList();
        }
    }

    /// <summary>
    /// �������� ������ ������ �������� �� ���������� ������
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void EachCorrectOperationWorksCorrectlyTest(IStack stack)
    {
        Assert.AreEqual(Calculator.Calculation("132", stack).Item1, 132);
        Assert.AreEqual(Calculator.Calculation("-12", stack).Item1, -12);
        Assert.AreEqual(Calculator.Calculation("1 2 45 * - 14 + 2 - 3 /", stack).Item1, -25.666666666666668);
        Assert.AreEqual(Calculator.Calculation("20 17 - 34 59 * + 74 - 1 130 / + 81 +", stack).Item1, 2016.0076923076922);
    }

    /// <summary>
    /// �������� ������ � �����������, ����������� 0
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void ExpressionsWithZeroTest(IStack stack)
    {
        Assert.AreEqual(Calculator.Calculation("5 0 +", stack).Item1, 5);
        Assert.AreEqual(Calculator.Calculation("0 47 +", stack).Item1, 47);
        Assert.AreEqual(Calculator.Calculation("0 2 -", stack).Item1, -2);
        Assert.AreEqual(Calculator.Calculation("4 0 -", stack).Item1, 4);
        Assert.AreEqual(Calculator.Calculation("4 0 *", stack).Item1, 0);
        Assert.AreEqual(Calculator.Calculation("0 -5 *", stack).Item1, 0);
        Assert.AreEqual(Calculator.Calculation("0 6 /", stack).Item1, 0);
    }

    /// <summary>
    /// �������� ��������� ������ ��� ������� �� 0
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void ExceptionInDivisionByZeroTest(IStack stack)
    {
        Assert.Throws<DivideByZeroException>(() => Calculator.Calculation("34 9287 + 123 4 * - 0 /", stack));
    }

    /// <summary>
    /// �������� ������ � �������������� �������
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void NegativeNumbersInStackTest(IStack stack)
    {
        Assert.AreEqual(Calculator.Calculation("-5 -4 +", stack).Item1, -9);
        Assert.AreEqual(Calculator.Calculation("-1 -17 -", stack).Item1, 16);
        Assert.AreEqual(Calculator.Calculation("-6 -3 *", stack).Item1, 18);
        Assert.AreEqual(Calculator.Calculation("-1024 -2 -", stack).Item1, -1022);
    }

    /// <summary>
    /// �������� ��������� ������ ��� ����� ������������ ������
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void ExceptionInIncorrectInputDataTest(IStack stack)
    {
        Assert.IsFalse(Calculator.Calculation("5 45647", stack).Item2);
        Assert.IsFalse(Calculator.Calculation("5 45647 - +", stack).Item2);
        Assert.Throws<IndexOutOfRangeException>(() => Calculator.Calculation("", stack));
        Assert.IsFalse(Calculator.Calculation("ww vfd +", stack).Item2);
        Assert.IsFalse(Calculator.Calculation("/", stack).Item2);
        Assert.IsFalse(Calculator.Calculation("1 * 2", stack).Item2);
    }
}
