using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EconomyModel
{
    public bool IsInitialized { get; private set; }

    public List<IncomeModel> IncomeModels {get {return _incomeModels;} }
    public List<ExpenseModel> ExpenseModels { get {return _expenseModels;} }

    private List<IncomeModel> _incomeModels = new List<IncomeModel> ();
    private List<ExpenseModel> _expenseModels = new List<ExpenseModel> ();

    public Context Context { get; private set; }

    public void Initialize(Context context)
    {
        if (!IsInitialized)
        {
            IsInitialized = true;
            Context = context;
            //Set Defaults
            IndustryModel IndustryProfit = new IndustryModel(1, "������� ������������ �����������", 417);
            IndustryModel Turnover = new IndustryModel(2, "������", 31670);
            IndustryModel BusinessProfit = new IndustryModel(3, "������ �����������", 5577);
            IndustryModel FarmingProfit = new IndustryModel(4, "������� �/� �����������", 446);
            IndustryModel PopulationProfit = new IndustryModel(5, "������ ���������", 16428);
            IndustryModel ForestProfit = new IndustryModel(6, "������ ������� ���������", 280);
            IndustryModel SocialInsurance = new IndustryModel(7, "���������� ����������� (������)", 684);
            //���� �� �������� ������ - ����� �����, ��� ������
            IndustryModel Unknown = new IndustryModel(8, "������", 2370);
            //��������
            IndustryModel TradeProfit = new IndustryModel(9, "������� � ��������", 75);

            IncomeModel IndustryProfitTax = new IncomeModel(1, "���������� ����� �� �����������", IndustryProfit, 12);
            IncomeModel TurnoverTax = new IncomeModel(2, "���/����� � �������", Turnover, 13);
            IncomeModel BusinessProfitTax = new IncomeModel(3, "���������� � ������� �����������", BusinessProfit, 81);
            IncomeModel FarmingTax = new IncomeModel(4, "����� �� �/� �����������", FarmingProfit, 13);
            IncomeModel PopulationProfitTax = new IncomeModel(5, "���������� �����", PopulationProfit, 7);
            IncomeModel ForestProfitTax = new IncomeModel(6, "����� �� ������� ������� ���������", ForestProfit, 15);
            IncomeModel SocialInsuranceTax = new IncomeModel(7, "���������� �����������", SocialInsurance, 100);

            IncomeModel UnknownTax = new IncomeModel(8, "������", Unknown, 100);
            IncomeModel TradeProfitTax = new IncomeModel(9, "��������", TradeProfit, 100);
            

            _incomeModels.Add(IndustryProfitTax);
            _incomeModels.Add(TurnoverTax);
            _incomeModels.Add(BusinessProfitTax);
            _incomeModels.Add(FarmingTax);
            _incomeModels.Add(PopulationProfitTax);
            _incomeModels.Add(ForestProfitTax);
            _incomeModels.Add(SocialInsuranceTax);

            _incomeModels.Add(UnknownTax);
            _incomeModels.Add(TradeProfitTax);

            ExpenseModel NationalEconomy = new ExpenseModel(1, "�������� ���������", 6208);
            ExpenseModel Defense = new ExpenseModel(2, "�������", 1492);
            ExpenseModel Managment = new ExpenseModel(3, "����������", 142);
            ExpenseModel Education = new ExpenseModel(4, "�����������", 1517);
            ExpenseModel Science = new ExpenseModel(5, "�����", 550);
            ExpenseModel Health = new ExpenseModel(6, "��������������", 767);
            ExpenseModel SocialProtection = new ExpenseModel(7, "���������� �����������", 1059);
            ExpenseModel SocialInsurancePayments = new ExpenseModel(8, "���������� ����������� (�������)", 642);
            ExpenseModel Propaganda = new ExpenseModel(9, "����������", 167);
            ExpenseModel NationalSecurity = new ExpenseModel(10, "����������", 334);

            _expenseModels.Add(NationalEconomy);
            _expenseModels.Add(Defense);
            _expenseModels.Add(Managment);
            _expenseModels.Add(Education);
            _expenseModels.Add(Science);
            _expenseModels.Add(SocialProtection);
            _expenseModels.Add(Health);
            _expenseModels.Add(SocialInsurancePayments);
            _expenseModels.Add(Propaganda);
            _expenseModels.Add(NationalSecurity);
        }
    }

    public float getIncome()
    {
        float income = 0f;
        foreach (IncomeModel incomeModel in _incomeModels)
        {
            income += incomeModel.Tax * incomeModel.IndustryModel.BusinessProfit / 100;
        }
        return income;
    }

    public float getExpense()
    {
        float expense = 0f;
        foreach (ExpenseModel expenseModel in _expenseModels)
        {
            expense += expenseModel.Expense;
        }
        return expense;
    }

    public float getProfit()
    {
        return getIncome() - getExpense();
    }

    public IncomeModel getIncomeModelById(int id)
    {
        foreach (IncomeModel incomeModel in _incomeModels)
        {
            if (incomeModel.Id == id)
            {
                return incomeModel;
            }
        }
        return null;
    }

    public ExpenseModel getExpenseModelById(int id)
    {
        foreach (ExpenseModel expenseModel in _expenseModels)
        {
            if (expenseModel.Id == id)
            { 
                return expenseModel;
            }
        }
        return null;
    }

    public void ApplyChanges()
    {
        foreach (IncomeModel incomeModel in _incomeModels)
        {
            incomeModel.ApplyChanges();
        }
        foreach (ExpenseModel expenseModel in _expenseModels)
        {
            expenseModel.ApplyChanges();
        }
    }

    public void ResetChanges()
    {
        foreach (IncomeModel incomeModel in _incomeModels)
        {
            incomeModel.ResetChanges();
        }
        foreach (ExpenseModel expenseModel in _expenseModels)
        {
            expenseModel.ResetChanges();
        }
    }
}
