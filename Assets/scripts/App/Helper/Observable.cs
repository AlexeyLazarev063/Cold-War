using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Observable<T>
{
    private T _value;

    // ������� ��� ����������� �� ��������� ��������
    public event Action<T, T> OnValueChanged;

    // �������� ��������
    public T Value
    {
        get => _value;
        set
        {
            if (!Equals(_value, value)) // ���������, ���������� �� ��������
            {
                T previousValue = _value;
                _value = value;
                OnValueChanged?.Invoke(previousValue, _value); // ���������� �����������
            }
        }
    }

    // �����������
    public Observable(T initialValue = default)
    {
        _value = initialValue;
    }

    // ����� ��� ���������� ���������
    public void AddListener(Action<T, T> listener)
    {
        OnValueChanged += listener;
    }

    // ����� ��� �������� ���������
    public void RemoveListener(Action<T, T> listener)
    {
        OnValueChanged -= listener;
    }
}
