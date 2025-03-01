using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EconomyController
{
    public bool IsInitialized { get; private set; }

    public Context Context { get; private set; }

    private EconomyModel _economyModel;
    private GameInterfaceUIView _gameInterfaceUIView;//Зачем?
    private EconomyInterfaceUIView _economyInterfaceUIView;

    public EconomyController(EconomyModel economy, GameInterfaceUIView gameInterfaceUIView, EconomyInterfaceUIView economyInterfaceUIView)
    {
        _economyModel = economy;
        _gameInterfaceUIView = gameInterfaceUIView;
        _economyInterfaceUIView = economyInterfaceUIView;
    }

    public void Initialize(Context context)
    {
        if (!IsInitialized)
        {
            IsInitialized = true;

            Context = context;
        }
    }

    public void RequiredIsInitialized()
    {
        if (!IsInitialized)
        {
            throw new Exception("Must be initialized!");
        }
    }

    public List<IncomeModel> getIncomeSettings()
    {
        return _economyModel?.IncomeModels;
    }

    public List<ExpenseModel> getExpenseSettings()
    {
        return _economyModel?.ExpenseModels;
    }

    public float getExpense()
    {
        return _economyModel.getExpense();
    }

    public float getIncome()
    {
        return _economyModel.getIncome();
    }

    public float getProfit()
    {
        return _economyModel.getProfit();
    }

    public void AddTax(int incomeModelId)
    {
        IncomeModel incomeModel = _economyModel.getIncomeModelById(incomeModelId);
        if (incomeModel != null)
        {
            incomeModel.ModifiedTax++;
            _economyInterfaceUIView.ShowIncomeSettings_OnClicked();
        }
    }

    public void ReduceTax(int incomeModelId)
    {
        IncomeModel incomeModel = _economyModel.getIncomeModelById(incomeModelId);
        if (incomeModel != null)
        {
            incomeModel.ModifiedTax--;
            _economyInterfaceUIView.ShowIncomeSettings_OnClicked();
        }
    }

    public void AddExpense(int expenseModelId, int expenseValue)
    {
        ExpenseModel expenseModel = _economyModel.getExpenseModelById(expenseModelId);
        if (expenseModel != null)
        {
            expenseModel.ModifiedExpense += expenseValue;
            _economyInterfaceUIView.ShowExpenseSettings_OnClicked();
        }
    }

    public void ReduceExpense(int expenseModelId, int expenseValue)
    {
        ExpenseModel expenseModel = _economyModel.getExpenseModelById(expenseModelId);
        if (expenseModel != null)
        {
            expenseModel.ModifiedExpense -= expenseValue;
            _economyInterfaceUIView.ShowExpenseSettings_OnClicked();
        }
    }

    public void ApplyChanges()
    {
        _economyModel.ApplyChanges();
    }

    public void ResetChanges()
    {
        _economyModel.ResetChanges();
    }
}
