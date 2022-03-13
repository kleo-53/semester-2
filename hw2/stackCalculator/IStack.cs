using System;

namespace StackCalculator
{
    public interface IStack
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

        /// <summary>
        /// Возвращает текущее количество элементов в стеке
        /// </summary>
        /// <returns>Количество элементов в стеке</returns>
        int Count();

        /// <summary>
        /// Проверка на то, пуст ли стек
        /// </summary>
        /// <returns>True, если стек пуст, false, если стек не пуст</returns>
        bool IsEmpty();
    }
}
