using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeOrderModel
{
    public int ResourceId { get; }
    public float Import { get; }
    public float Export { get; }

    private int _resourceId;
    private float _import;
    private float _export;

    public TradeOrderModel(int resourceId, float import, float export)
    {
        _resourceId = resourceId;
        _import = import;
        _export = export;
    }

    public void SetImport(float import)
    {
        _import = import;
    }

    public void SetExport(float export)
    { 
        _export = export;
    }
}
