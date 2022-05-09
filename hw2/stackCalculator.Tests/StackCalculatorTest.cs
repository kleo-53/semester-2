namespace stackCalculator.Tests;

using NUnit.Framework;
using StackCalculator;
using System.Collections.Generic;
using System;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    private static IEnumerable<IStack> StackToTest
    {
        get
        {
            yield return new StackOnArray();
            yield return new StackOnList();
        }
    }

    private const double epsilon = 1e-7;

    /// <summary>
    /// �������� ������ ������ �������� �� ���������� ������
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void EachCorrectOperationWorksCorrectlyTest(IStack stack)
    {
        Assert.IsTrue(Calculator.Calculation("132", stack).Item1 - 132 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("-12", stack).Item1 + 12 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("1 2 45 * - 14 + 2 - 3 /", stack).Item1 + 25.66666 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("20 17 - 34 59 * + 74 - 1 130 / + 81 +", stack).Item1 - 2016.0076923 <= epsilon);
    }

    /// <summary>
    /// �������� ������ � �����������, ����������� 0
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void ExpressionsWithZeroTest(IStack stack)
    {
        Assert.IsTrue(Calculator.Calculation("5 0 +", stack).Item1 - 5 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("0 47 +", stack).Item1 - 47 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("0 2 -", stack).Item1 + 2 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("4 0 -", stack).Item1 - 4 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("4 0 *", stack).Item1 + 0 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("0 -5 *", stack).Item1 + 0 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("0 6 /", stack).Item1 + 0 <= epsilon);
    }

    /// <summary>
    /// �������� ��������� ������ ��� ������� �� 0
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void ExceptionInDivisionByZeroTest(IStack stack)
    {
        Assert.Throws<DivideByZeroException>(() => { Calculator.Calculation("34 9287 + 123 4 * - 0 /", stack); });
    }

    /// <summary>
    /// �������� ������ � �������������� �������
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void NegativeNumbersInStackTest(IStack stack)
    {
        Assert.IsTrue(Calculator.Calculation("-5 -4 +", stack).Item1 + 1 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("-1 -17 -", stack).Item1 - 16 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("-6 -3 *", stack).Item1 - 18 <= epsilon);
        Assert.IsTrue(Calculator.Calculation("-1024 -2 -", stack).Item1 - 512 <= epsilon);
    }

    /// <summary>
    /// �������� ��������� ������ ��� ����� ������������ ������
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void ExceptionInIncorrectInputDataTest(IStack stack)
    {
        Assert.IsFalse(Calculator.Calculation("5 45647", stack).Item2);
        Assert.IsFalse(Calculator.Calculation("5 45647 - +", stack).Item2);
        Assert.Throws<IndexOutOfRangeException>(() => { Calculator.Calculation("", stack); } );
        Assert.IsFalse(Calculator.Calculation("ww vfd +", stack).Item2);
        Assert.IsFalse(Calculator.Calculation("/", stack).Item2);
        Assert.IsFalse(Calculator.Calculation("1 * 2", stack).Item2);
    }
}
