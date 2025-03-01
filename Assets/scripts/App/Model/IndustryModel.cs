using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustryModel
{
    public int BusinessProfit { get { return _businessProfit; } }

    private int _id;
    private string _name;
    private int _businessProfit;

    public IndustryModel(int id, string name, int businessProfit)
    {
        _id = id;
        _name = name;
        _businessProfit = businessProfit;
    }
}
