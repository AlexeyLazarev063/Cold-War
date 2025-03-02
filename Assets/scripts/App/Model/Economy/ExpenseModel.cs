using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpenseModel
{
    public int Id { get { return _id; } }
    public int Expense { get { return _expense; } }
    public string Name { get { return _name; } }
    public int ModifiedExpense { get { return _modifiedExpense; } set { _modifiedExpense = value; } }

    private int _id;
    private string _name;
    private int _expense;
    private int _modifiedExpense;

    public ExpenseModel(int id, string name, int expense)
    {
        _id = id;
        _name = name;
        _expense = expense;
        _modifiedExpense = _expense;
    }

    public void ApplyChanges()
    {
        _expense = _modifiedExpense;
    }

    public void ResetChanges()
    {
        _modifiedExpense = _expense;
    }
}
