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
            IndustryModel IndustryProfit = new IndustryModel(1, "Прибыль промышленных предприятий", 417);
            IndustryModel Turnover = new IndustryModel(2, "Оборот", 31670);
            IndustryModel BusinessProfit = new IndustryModel(3, "Оборот предприятий", 5577);
            IndustryModel FarmingProfit = new IndustryModel(4, "Прибыль с/х предприятий", 446);
            IndustryModel PopulationProfit = new IndustryModel(5, "Доходы населения", 16428);
            IndustryModel ForestProfit = new IndustryModel(6, "Доходы лесного хозяйства", 280);
            IndustryModel SocialInsurance = new IndustryModel(7, "Социальное страхование (уплата)", 684);
            //Пока не придумал откуда - везде пишут, как прочие
            IndustryModel Unknown = new IndustryModel(8, "Другое", 2370);
            //Временно
            IndustryModel TradeProfit = new IndustryModel(9, "Прибыль с торговли", 75);

            IncomeModel IndustryProfitTax = new IncomeModel(1, "Подоходный налог на предприятия", IndustryProfit, 12);
            IncomeModel TurnoverTax = new IncomeModel(2, "НДС/Налог с оборота", Turnover, 13);
            IncomeModel BusinessProfitTax = new IncomeModel(3, "Отчисления с оборота предприятий", BusinessProfit, 81);
            IncomeModel FarmingTax = new IncomeModel(4, "Налог на с/х предприятия", FarmingProfit, 13);
            IncomeModel PopulationProfitTax = new IncomeModel(5, "Подоходный налог", PopulationProfit, 7);
            IncomeModel ForestProfitTax = new IncomeModel(6, "Налог на прибыль лесного хозяйства", ForestProfit, 15);
            IncomeModel SocialInsuranceTax = new IncomeModel(7, "Социальное страхование", SocialInsurance, 100);

            IncomeModel UnknownTax = new IncomeModel(8, "Другое", Unknown, 100);
            IncomeModel TradeProfitTax = new IncomeModel(9, "Торговля", TradeProfit, 100);
            

            _incomeModels.Add(IndustryProfitTax);
            _incomeModels.Add(TurnoverTax);
            _incomeModels.Add(BusinessProfitTax);
            _incomeModels.Add(FarmingTax);
            _incomeModels.Add(PopulationProfitTax);
            _incomeModels.Add(ForestProfitTax);
            _incomeModels.Add(SocialInsuranceTax);

            _incomeModels.Add(UnknownTax);
            _incomeModels.Add(TradeProfitTax);

            ExpenseModel OilProductionExpense = new ExpenseModel(1, "Добыча нефти", 875);
            ExpenseModel GazProductionExpense = new ExpenseModel(2, "Добыча газа", 375);
            ExpenseModel FoodProductionExpense = new ExpenseModel(3, "Пищевая промышленность", 1042);
            ExpenseModel GoldProductionExpense = new ExpenseModel(4, "Добыча золота", 125);
            ExpenseModel MetalProductionExpense = new ExpenseModel(5, "Производство металла", 875);
            ExpenseModel EnergyProductionExpense = new ExpenseModel(6, "Производство электроэнергии", 750);
            ExpenseModel GoodsProductionExpense = new ExpenseModel(7, "Производство прочих товаров", 1600);
            ExpenseModel CoalProductionExpense = new ExpenseModel(8, "Добыча угля", 375);
            ExpenseModel ForestProductionExpense = new ExpenseModel(9, "Лесная промышленность", 125);
            ExpenseModel Defense = new ExpenseModel(10, "Оборона", 1492);
            ExpenseModel Managment = new ExpenseModel(11, "Управление", 142);
            ExpenseModel Education = new ExpenseModel(12, "Просвещение", 1517);
            ExpenseModel Science = new ExpenseModel(13, "Наука", 550);
            ExpenseModel Health = new ExpenseModel(14, "Здравохранение", 767);
            ExpenseModel SocialProtection = new ExpenseModel(15, "Социальное обеспечение", 1059);
            ExpenseModel SocialInsurancePayments = new ExpenseModel(16, "Социальное страхование (выплаты)", 642);
            ExpenseModel Propaganda = new ExpenseModel(17, "Пропаганда", 167);
            ExpenseModel NationalSecurity = new ExpenseModel(18, "Спецслужбы", 334);

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
