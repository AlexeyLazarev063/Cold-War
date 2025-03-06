using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceModel
{
    public int Id { get { return _id; } }
    public string Name { get { return _name; } }
    public string Measure { get { return _measure; } }
    public float Production { get { return _production; } }
    public float Consumption { get { return _consumption; } }
    public int WorkersNeed { get { return _workersNeed; } }
    public int CostPrice { get { return _costPrice; } }

    private int _id;
    private string _name;
    private string _measure;
    private float _production;
    private float _consumption;
    //в тыс. человек
    private int _workersNeed;
    //Себестоимость за млн.т.
    private int _costPrice;

    public ResourceModel(int id, string name, string measure, float production, float consumption, int workersNeed, int costPrice)
    {
        _id = id;
        _name = name;
        _measure = measure;
        _production = production;
        _consumption = consumption;
        _workersNeed = workersNeed;
        _costPrice = costPrice;
    }

    public void ChangeProduction(float production)
    { 
        _production += production;
    }
}
