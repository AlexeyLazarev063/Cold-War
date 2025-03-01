using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeModel
{
    public bool IsInitialized { get; private set; }

    public Context Context { get; private set; }

    public List<TradeOrderModel> TradeOrderModels { get { return _tradeOrderModels; } }

    private List<TradeOrderModel> _tradeOrderModels = new List<TradeOrderModel> ();

    public void Initialize(Context context)
    {
        if (!IsInitialized)
        {
            IsInitialized = true;
            Context = context;

            TradeOrderModel oilOrder = new TradeOrderModel(1, 0f, 0f);
            TradeOrderModel gazOrder = new TradeOrderModel(2, 0f, 0f);
            TradeOrderModel goldOrder = new TradeOrderModel(3, 0f, 0f);
            TradeOrderModel metalOrder = new TradeOrderModel(4, 0f, 0f);
            TradeOrderModel foodOrder = new TradeOrderModel(5, 0f, 0f);
            TradeOrderModel electricityOrder = new TradeOrderModel(6, 0f, 0f);
            TradeOrderModel coalOrder = new TradeOrderModel(7, 0f, 0f);
            TradeOrderModel forestOrder = new TradeOrderModel(8, 0f, 0f);
            TradeOrderModel goodsOrder = new TradeOrderModel(9, 0f, 0f);

            _tradeOrderModels.Add(oilOrder);
            _tradeOrderModels.Add(gazOrder);
            _tradeOrderModels.Add(goldOrder);
            _tradeOrderModels.Add(metalOrder);
            _tradeOrderModels.Add(foodOrder);
            _tradeOrderModels.Add(electricityOrder);
            _tradeOrderModels.Add(coalOrder);
            _tradeOrderModels.Add(forestOrder);
            _tradeOrderModels.Add(goodsOrder);
        }
    }
}
