using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeModel
{
    public int Id { get { return _id; } }
    public int Tax { get { return _tax; } }
    public string Name { get { return _name; } }
    public IndustryModel IndustryModel { get { return _industryModel; } }
    public int ModifiedTax { get { return _modifiedTax; } set { _modifiedTax = value; } }

    private int _id;
    private string _name;
    private IndustryModel _industryModel;
    private int _tax;
    private int _modifiedTax;

    public IncomeModel(int id, string name, IndustryModel industryModel, int tax)
    {
        _id = id;
        _name = name;
        _industryModel = industryModel;
        _tax = tax;
        _modifiedTax = _tax;
    }

    public void ApplyChanges()
    {
        _tax = _modifiedTax;
    }

    public void ResetChanges()
    {
        _modifiedTax = _tax;
    }
}
