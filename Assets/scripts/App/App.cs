using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App
{
    public bool IsInitialized { get; private set; }

    private Context _context;

    private GameInterfaceUIView _gameInterfaceUIView;
    private EconomyInterfaceUIView _economyInterfaceUIView;

    public App(GameInterfaceUIView gameInterfaceUIView, EconomyInterfaceUIView economyInterfaceUIView)
    {
        _gameInterfaceUIView = gameInterfaceUIView;
        _economyInterfaceUIView = economyInterfaceUIView;
    }

    public void Initialize()
    {
        if (!IsInitialized)
        {
            IsInitialized = true;
            //DI-контейнер (регистратор зависимостей)
            _context = new Context();

            PointsModel pointsModel = new PointsModel();
            StepModel stepModel = new StepModel();
            EconomyModel economyModel = new EconomyModel();
            DateModel dateModel = new DateModel();
            ProductionModel productionModel = new ProductionModel();
            TradeModel tradeModel = new TradeModel();

            _context.Register(pointsModel);
            _context.Register(stepModel);
            _context.Register(dateModel);

            EconomyController economyController = new EconomyController(economyModel, _gameInterfaceUIView, _economyInterfaceUIView);
            StepController stepController = new StepController(economyModel, stepModel, pointsModel, dateModel, _gameInterfaceUIView);

            _context.Register(economyController);

            economyModel.Initialize(_context);
            stepModel.Initialize(_context);
            pointsModel.Initialize(_context);
            dateModel.Initialize(_context);
            productionModel.Initialize(_context);
            tradeModel.Initialize(_context);

            _gameInterfaceUIView.Initialize(_context);
            _economyInterfaceUIView.Initialize(_context);

            economyController.Initialize(_context);
            stepController.Initialize(_context);
 
        }
    }
}
