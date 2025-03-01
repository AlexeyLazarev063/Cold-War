using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsModel
{
    public bool IsInitialized { get; private set; }

    public Context Context { get; private set; }

    public Observable<float> Money { get { return _money; } }
    public float Population { get { return _population; } }
    public int Support { get { return _support; } }
    public float MobilizationReserve { get { return _mobilizationReserve; } }
    public float TradeBalance { get { return _tradeBalance; } }
    public int Stability { get { return _stability; } }
    public float Inflation { get { return _inflation; } }
    public int LifeQuality { get { return _lifeQuality; } }
    public float Corruption { get { return _corruption; } }

    private Observable<float> _money = new Observable<float>();
    private float _population;
    private int _support;
    private float _mobilizationReserve;
    private float _tradeBalance;
    private int _stability;
    private float _inflation;
    private int _lifeQuality;
    private float _corruption;

    public void Initialize(Context context)
    {
        IsInitialized = true;

        Context = context;
        //в млн.
        _money.Value = 200f;
        _population = 241.7f;
        _support = 89;
        _mobilizationReserve = 60f;
        _tradeBalance = 900f;
        _stability = 90;
        _inflation = 3f;
        _lifeQuality = 65;
        _corruption = 30f;
    }

    public void AddMoney(float money)
    {
        _money.Value += money;
    }

    public void AddPopulation(float population)
    {
        _population += population;
    }

    public void AddSupport(int support)
    {
        _support += support;
    }

    public void AddMobilizationReserve(float mobilizationReserve)
    {
        _mobilizationReserve += mobilizationReserve;
    }

    public void SetTradeBalance(float tradeBalance)
    {
        _tradeBalance = tradeBalance;
    }

    public void AddStability(int stability)
    {
        _stability += stability;
    }

    public void AddInflation(float inflation)
    {
        _inflation += inflation;
    }
}
