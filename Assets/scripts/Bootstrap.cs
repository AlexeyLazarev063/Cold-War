using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameInterfaceUIView _gameInterfaceUIView;
    [SerializeField] private EconomyInterfaceUIView _economyInterfaceUIView;

    protected void Start()
    {
        App app = new App(_gameInterfaceUIView, _economyInterfaceUIView);
        app.Initialize();
    }
}
