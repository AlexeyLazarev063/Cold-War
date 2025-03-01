using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StepController
{
    public bool IsInitialized { get; private set; }

    public Context Context { get; private set; }

    private EconomyModel _economyModel;
    private StepModel _stepModel;
    private PointsModel _pointsModel;
    private DateModel _dateModel;

    private GameInterfaceUIView _gameInterfaceUIView;

    public StepController(EconomyModel economy, StepModel stepModel, PointsModel pointsModel, DateModel dateModel, GameInterfaceUIView gameInterfaceUIView)
    {
        _economyModel = economy;
        _stepModel = stepModel;
        _pointsModel = pointsModel;
        _dateModel = dateModel;

        _gameInterfaceUIView = gameInterfaceUIView;
    }

    public void Initialize(Context context)
    {
        if (!IsInitialized)
        {
            IsInitialized = true;

            Context = context;

            _gameInterfaceUIView.NextStep.AddListener(View_NextStep);
        }
    }

    public void RequiredIsInitialized()
    {
        if (!IsInitialized)
        {
            throw new Exception("Must be initialized!");
        }
    }

    private void View_NextStep()
    {
        RequiredIsInitialized();
        _pointsModel.AddMoney(_economyModel.getProfit());
        _stepModel.AddStep();
        _dateModel.NextDate(_stepModel.StepNumber);
    }
}
