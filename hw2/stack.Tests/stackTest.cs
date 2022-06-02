namespace stack.Tests;

using NUnit.Framework;
using StackCalculator;
using System.Collections.Generic;

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
    /// �������� ������� ���������� �������� � ���� � ���������� ������ ������� IsEmpty
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void PushToStackWorksCorrectlyTest(IStack stack)
    {
        Assert.IsTrue(stack.IsEmpty);
        stack.Push(1);
        Assert.IsFalse(stack.IsEmpty);
    }

    /// <summary>
    /// �������� ������� IsEmpty ����� ���������� � �������� �������� �� �����
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void StackIsEmptyAfterPushAndPopTest(IStack stack)
    {
        Assert.IsTrue(stack.IsEmpty);
        stack.Push(1);
        stack.Pop();
        Assert.IsTrue(stack.IsEmpty);
    }

    /// <summary>
    /// �������� ������ �������� First-In-Last-Out ��� ���� ���������
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void PopWithThreeElementsFromStackWorksCorrectlyTest(IStack stack)
    {
        stack.Push(1);
        stack.Push(3);
        stack.Push(2);
        Assert.AreEqual(2, stack.Pop().Item1);
        Assert.AreEqual(3, stack.Pop().Item1);
        Assert.AreEqual(1, stack.Pop().Item1);
    }

    /// <summary>
    /// �������� ��������� ������ ��� ������� ������� ������� �� ������� �����
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void PopWithNoPushThrowsExceptionTest(IStack stack)
    {
        Assert.IsFalse(stack.Pop().Item2);
    }
}
