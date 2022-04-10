using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueList;

public class UUniqueList : UList
{
    /// <summary>
    /// Добавляет элемент в конец списка
    /// </summary>
    /// <param name="value">Добавляемый элемент</param>
    /// <exception cref="AddRepeatedElementException">Ошибка при добавлении повторяющегося элемента</exception>
    public new void Add(int value)
    {
        if (base.IsContain(value))
        {
            throw new AddRepeatedElementException();
        }
        base.Add(value);
    }

    /// <summary>
    /// Добавляет элемент в заданную позицию
    /// </summary>
    /// <param name="value">Добавляемый элемент</param>
    /// <param name="position">Позиция, в которую нужно добавить элемент</param>
    /// <exception cref="AddRepeatedElementException">Ошибка при добавлении повторяющегося элемента</exception>
    public new void Add(int value, int position)
    {
        if (base.IsContain(value))
        {
            throw new AddRepeatedElementException();
        }
        base.Add(value, position);
    }
}
