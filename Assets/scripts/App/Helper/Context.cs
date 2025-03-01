using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Context
{
    private readonly Dictionary<Type, object> _items = new Dictionary<Type, object>();

    // ����������� �������
    public void Register<T>(T instance)
    {
        _items[typeof(T)] = instance;
    }

    // ��������� �������
    public T GetItem<T>()
    {
        if (_items.TryGetValue(typeof(T), out var instance))
        {
            return (T)instance;
        }
        throw new InvalidOperationException($"Dependency of type {typeof(T)} is not registered.");
    }
}
