using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpenseOnResourceProductionModel
{
    public int ResourceId { get { return _resourceId; } }
    public int ExpenseId {  get { return _expenseId; } }

    private int _resourceId;
    private int _expenseId;

    public ExpenseOnResourceProductionModel(int resourceId, int expenseId)
    {
        _resourceId = resourceId;
        _expenseId = expenseId;
    }
}
