using NUnit.Framework;
using StackCalculator;
using System.Collections.Generic;
using System;

namespace stack.Tests;

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
    /// Проверка функции добавления элемента в стек и корректной работы функции IsEmpty
    /// </summary>
    [TestCaseSource(nameof(StackToTest))]
    public void PushToStackWorksCorrectlyTest(IStack stack)
    {
        Assert.IsTrue(stack.IsEmpty);
        stack.Push(1);
        Assert.IsFalse(stack.IsEmpty);
    }

    /// <summary>
    /// Проверка функции IsEmpty после добавления и удаления элемента из стека
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
    /// Проверка работы принципа First-In-Last-Out для трех элементов
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
    /// Проверка появления ошибки при попытке удалить элемент из пустого стека
    /// </summary>
    [Test, TestCaseSource(nameof(StackToTest))]
    public void PopWithNoPushThrowsExceptionTest(IStack stack)
    {
        Assert.IsFalse(stack.Pop().Item2);
    }
}
