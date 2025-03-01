using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Observable<T>
{
    private T _value;

    // Событие для уведомления об изменении значения
    public event Action<T, T> OnValueChanged;

    // Значение свойства
    public T Value
    {
        get => _value;
        set
        {
            if (!Equals(_value, value)) // Проверяем, изменилось ли значение
            {
                T previousValue = _value;
                _value = value;
                OnValueChanged?.Invoke(previousValue, _value); // Уведомляем подписчиков
            }
        }
    }

    // Конструктор
    public Observable(T initialValue = default)
    {
        _value = initialValue;
    }

    // Метод для добавления слушателя
    public void AddListener(Action<T, T> listener)
    {
        OnValueChanged += listener;
    }

    // Метод для удаления слушателя
    public void RemoveListener(Action<T, T> listener)
    {
        OnValueChanged -= listener;
    }
}
