using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EconomyModel
{
    public bool IsInitialized { get; private set; }

    public List<IncomeModel> IncomeModels {get {return _incomeModels;} }
    public List<ExpenseModel> ExpenseModels { get {return _expenseModels;} }
    public List<ExpenseOnResourceProductionModel> ExpenseOnResourceProductionModel { get { return _expenseOnResourceProductionModel; } }

    private List<IncomeModel> _incomeModels = new List<IncomeModel> ();
    private List<ExpenseModel> _expenseModels = new List<ExpenseModel> ();
    private List<ExpenseOnResourceProductionModel> _expenseOnResourceProductionModel = new List<ExpenseOnResourceProductionModel> ();

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

            ExpenseModel OilProductionExpense = new ExpenseModel(1, "������ �����", 875);
            ExpenseModel GazProductionExpense = new ExpenseModel(2, "������ ����", 375);
            ExpenseModel FoodProductionExpense = new ExpenseModel(3, "������� ��������������", 1042);
            ExpenseModel GoldProductionExpense = new ExpenseModel(4, "������ ������", 125);
            ExpenseModel MetalProductionExpense = new ExpenseModel(5, "������������ �������", 875);
            ExpenseModel EnergyProductionExpense = new ExpenseModel(6, "������������ ��������������", 750);
            ExpenseModel GoodsProductionExpense = new ExpenseModel(7, "������������ ������ �������", 1600);
            ExpenseModel CoalProductionExpense = new ExpenseModel(8, "������ ����", 375);
            ExpenseModel ForestProductionExpense = new ExpenseModel(9, "������ ��������������", 125);
            ExpenseModel Defense = new ExpenseModel(10, "�������", 1492);
            ExpenseModel Managment = new ExpenseModel(11, "����������", 142);
            ExpenseModel Education = new ExpenseModel(12, "�����������", 1517);
            ExpenseModel Science = new ExpenseModel(13, "�����", 550);
            ExpenseModel Health = new ExpenseModel(14, "��������������", 767);
            ExpenseModel SocialProtection = new ExpenseModel(15, "���������� �����������", 1059);
            ExpenseModel SocialInsurancePayments = new ExpenseModel(16, "���������� ����������� (�������)", 642);
            ExpenseModel Propaganda = new ExpenseModel(17, "����������", 167);
            ExpenseModel NationalSecurity = new ExpenseModel(18, "����������", 334);

            _expenseModels.Add(OilProductionExpense);
            _expenseModels.Add(GazProductionExpense);
            _expenseModels.Add(FoodProductionExpense);
            _expenseModels.Add(GoldProductionExpense);
            _expenseModels.Add(MetalProductionExpense);
            _expenseModels.Add(EnergyProductionExpense);
            _expenseModels.Add(GoodsProductionExpense);
            _expenseModels.Add(CoalProductionExpense);
            _expenseModels.Add(ForestProductionExpense);
            _expenseModels.Add(Defense);
            _expenseModels.Add(Managment);
            _expenseModels.Add(Education);
            _expenseModels.Add(Science);
            _expenseModels.Add(SocialProtection);
            _expenseModels.Add(Health);
            _expenseModels.Add(SocialInsurancePayments);
            _expenseModels.Add(Propaganda);
            _expenseModels.Add(NationalSecurity);

            ExpenseOnResourceProductionModel Oil = new ExpenseOnResourceProductionModel(1, 1);
            ExpenseOnResourceProductionModel Gaz = new ExpenseOnResourceProductionModel(2, 2);
            ExpenseOnResourceProductionModel Gold = new ExpenseOnResourceProductionModel(3, 4);
            ExpenseOnResourceProductionModel Metal = new ExpenseOnResourceProductionModel(4, 5);
            ExpenseOnResourceProductionModel Food = new ExpenseOnResourceProductionModel(5, 3);
            ExpenseOnResourceProductionModel Electricity = new ExpenseOnResourceProductionModel(6, 6);
            ExpenseOnResourceProductionModel Coal = new ExpenseOnResourceProductionModel(7, 8);
            ExpenseOnResourceProductionModel Forest = new ExpenseOnResourceProductionModel(8, 9);
            ExpenseOnResourceProductionModel Goods = new ExpenseOnResourceProductionModel(9, 7);

            _expenseOnResourceProductionModel.Add(Oil);
            _expenseOnResourceProductionModel.Add(Gaz);
            _expenseOnResourceProductionModel.Add(Gold);
            _expenseOnResourceProductionModel.Add(Metal);
            _expenseOnResourceProductionModel.Add(Food);
            _expenseOnResourceProductionModel.Add(Electricity);
            _expenseOnResourceProductionModel.Add(Coal);
            _expenseOnResourceProductionModel.Add(Forest);
            _expenseOnResourceProductionModel.Add(Goods);
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

    public int GetExpenseByResourceId(int resourceId)
    {
        foreach (ExpenseOnResourceProductionModel expenseOnResourceProductionModel in _expenseOnResourceProductionModel)
        {
            if (expenseOnResourceProductionModel.ResourceId == resourceId)
            {
                ExpenseModel ExpenseModel = getExpenseModelById(expenseOnResourceProductionModel.ExpenseId);
                return ExpenseModel.Expense;
            }
        }
        return 0;
    }
}
