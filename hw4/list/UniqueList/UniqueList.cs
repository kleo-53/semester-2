namespace UniqueList;

/// <summary>
/// Unique list
/// </summary>
public class UniqueList : List
{
    /// <summary>
    /// Добавляет элемент в конец списка
    /// </summary>
    /// <param name="value">Добавляемый элемент</param>
    /// <exception cref="AddRepeatedElementException">Ошибка при добавлении повторяющегося элемента</exception>
    public override void Add(int value)
    {
        if (base.Contains(value))
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
    public override void Add(int value, int position)
    {
        if (base.Contains(value))
        {
            throw new AddRepeatedElementException();
        }
        base.Add(value, position);
    }

    /// <summary>
    /// Изменение значения по позиции
    /// </summary>
    /// <param name="value">Данное значение</param>
    /// <param name="position">Позиция</param>
    public override void Change(int value, int position)
    {
        if (base.Contains(value))
        {
            throw new AddRepeatedElementException();
        }
        base.Change(value, position);
    }
}
