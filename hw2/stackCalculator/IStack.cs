using System;

namespace StackCalculator.Tests
{
    internal interface IStack
    {
        /// <summary>
        /// Добавляет элемент в стек
        /// </summary>
        /// <param name="element">Добавляемый элемент</param>
        void Push(double element);
        /// <summary>
        /// Удаляет и возвращает верхний элемент стека
        /// </summary>
        /// <returns>Удаленный элемент</returns>
        double Pop();
        int Count();
    }
}
