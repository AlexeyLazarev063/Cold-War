using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EconomyInterfaceUIView : MonoBehaviour
{
    public bool IsInitialized { get; private set; }

    public Context Context { get; private set; }

    public Button CloseWindowButton { get {  return _closeWindowButton; } }
    public Button OpenEconomyPanel { get { return _openEconomyPanel; } }
    public Button ApplyChangesButton { get { return _applyChangesButton; } }
    public Button ResetChangesButton { get { return _resetChangesButton; } }

    [SerializeField] private Button _closeWindowButton;
    [SerializeField] private Button _openEconomyPanel; // ������ ��� �������� ����
    [SerializeField] private Button _openIncomeTab; // ������ ��� �������� ����
    [SerializeField] private Button _openExpenseTab; // ������ ��� �������� ����
    [SerializeField] private Button _openSummaryTab; // ������ ��� �������� ����
    [SerializeField] private Button _applyChangesButton; // ������ ��� �������� ����
    [SerializeField] private Button _resetChangesButton; // ������ ��� �������� ����

    [SerializeField] private Transform _scrollContent; // ��������� ��� ��������
    [SerializeField] private GameObject _itemPrefab; // ������ �������� ������
    [SerializeField] private GameObject _itemSummaryPrefab; // ������ �������� ������

    [SerializeField] private GameObject _economyPanel;

    [SerializeField] private Color32 _selectColor;
    [SerializeField] private Color32 _freeColor;
    [SerializeField] private Color32 _textColor;

    [SerializeField] private Image _incomeTabBackground;
    [SerializeField] private Image _expenseTabBackground;
    [SerializeField] private Image _summaryTabBackground;

    [SerializeField] private ScrollRect _scrollRect;

    private int selectedTab = 1;

    public void Initialize(Context context)
    {
        if (!IsInitialized)
        {
            IsInitialized = true;
            Context = context;
            _selectColor = new Color32(242, 242, 226, 255);
            _freeColor = new Color32(224, 224, 191, 255);
            _textColor = new Color32(140, 135, 88, 255);
            _closeWindowButton.onClick.AddListener(CloseEconomyPanel_OnClicked);
            _openEconomyPanel.onClick.AddListener(OpenEconomyPanel_OnClicked);
            _openIncomeTab.onClick.AddListener(ShowIncomeSettings_OnClicked);
            _openExpenseTab.onClick.AddListener(ShowExpenseSettings_OnClicked);
            _openSummaryTab.onClick.AddListener(ShowSummary_OnClicked);
            _applyChangesButton.onClick.AddListener(ApplyChanges_OnClicked);
            _resetChangesButton.onClick.AddListener(ResetChanges_OnClicked);
        }
    }

    public void ShowIncomeSettings_OnClicked()
    {
        ResetContent();
        _incomeTabBackground.color = _selectColor;
        _expenseTabBackground.color = _freeColor;
        _summaryTabBackground.color = _freeColor;
        ShowIncomeSettings();
        _scrollRect.verticalNormalizedPosition = 1;
        selectedTab = 1;
    }

    public void ShowExpenseSettings_OnClicked()
    {
        ResetContent();
        _incomeTabBackground.color = _freeColor;
        _expenseTabBackground.color = _selectColor;
        _summaryTabBackground.color = _freeColor;
        ShowExpenseSettings();
        _scrollRect.verticalNormalizedPosition = 1;
        selectedTab = 2;
    }

    private void ShowSummary_OnClicked()
    {
        ResetContent();
        _incomeTabBackground.color = _freeColor;
        _expenseTabBackground.color = _freeColor;
        _summaryTabBackground.color = _selectColor;
        ShowSummary();
    }

    private void ApplyChanges_OnClicked()
    {
        EconomyController economyController = Context.GetItem<EconomyController>();
        economyController.ApplyChanges();
        ResetContent();
        if (selectedTab == 1)
        {
            ShowIncomeSettings();
        }
        else if (selectedTab == 2)
        {

            ShowExpenseSettings();
        }
    }

    private void ResetChanges_OnClicked()
    {
        EconomyController economyController = Context.GetItem<EconomyController>();
        economyController.ResetChanges();
        ResetContent();
        if (selectedTab == 1)
        {
            ShowIncomeSettings();
        }
        else if (selectedTab == 2)
        {

            ShowExpenseSettings();
        }
    }

    private void ResetContent()
    {
        foreach (Transform child in _scrollContent)
        {
            Destroy(child.gameObject);
        }
    }

    private void CloseEconomyPanel_OnClicked()
    {
        _economyPanel.SetActive(false);
    }

    private void OpenEconomyPanel_OnClicked()
    {
        ResetContent();
        ShowIncomeSettings();
        _scrollRect.verticalNormalizedPosition = 1;
        _economyPanel.SetActive(true);
    }

    private void ShowIncomeSettings()
    {
        EconomyController economyController = Context.GetItem<EconomyController>();
        List<IncomeModel> incomeModels = economyController.getIncomeSettings();

        // ������� ����� ��������
        foreach (IncomeModel incomeModel in incomeModels)
        {
            GameObject itemObject = Instantiate(_itemPrefab, _scrollContent);

            Transform textTransform = itemObject.transform.Find("Name/TaxName");
            if (textTransform != null)
            {
                TextMeshProUGUI textComponent = textTransform.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    textComponent.text = incomeModel.Name;
                }
            }

            textTransform = itemObject.transform.Find("Value/TaxValue");
            if (textTransform != null)
            {
                TextMeshProUGUI textComponent = textTransform.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    if (incomeModel.ModifiedTax != incomeModel.Tax)
                    {
                        textComponent.text = incomeModel.ModifiedTax.ToString() + "%";
                        textComponent.color = Color.green;
                    } else
                    {
                        textComponent.text = incomeModel.Tax.ToString() + "%";
                        textComponent.color = _textColor;
                    }
                }
            }
            
            Transform buttonTransform = itemObject.transform.Find("Plus/Button");
            if (buttonTransform != null)
            {
                Button buttonComponent = buttonTransform.GetComponent<Button>();
                if (buttonComponent != null)
                {
                    buttonComponent.onClick.AddListener(() => economyController.AddTax(incomeModel.Id));
                }
            }
            
            buttonTransform = itemObject.transform.Find("Minus/Button");
            if (buttonTransform != null)
            {
                Button buttonComponent = buttonTransform.GetComponent<Button>();
                if (buttonComponent != null)
                {
                    buttonComponent.onClick.AddListener(() => economyController.ReduceTax(incomeModel.Id));
                }
            }
        }
    }

    private void ShowExpenseSettings()
    {
        EconomyController economyController = Context.GetItem<EconomyController>();
        List<ExpenseModel> ExpenseModels = economyController.getExpenseSettings();

        // ������� ����� ��������
        foreach (ExpenseModel expenseModel in ExpenseModels)
        {
            GameObject itemObject = Instantiate(_itemPrefab, _scrollContent);

            Transform textTransform = itemObject.transform.Find("Name/TaxName");
            if (textTransform != null)
            {
                TextMeshProUGUI textComponent = textTransform.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    textComponent.text = expenseModel.Name;
                }
            }

            textTransform = itemObject.transform.Find("Value/TaxValue");
            if (textTransform != null)
            {
                TextMeshProUGUI textComponent = textTransform.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    if (expenseModel.ModifiedExpense != expenseModel.Expense)
                    {
                        textComponent.text = expenseModel.ModifiedExpense.ToString() + " ���.";
                        textComponent.color = Color.green;
                    }
                    else
                    {
                        textComponent.text = expenseModel.Expense.ToString() + " ���.";
                        textComponent.color = _textColor;
                    }
                }
            }

            Transform buttonTransform = itemObject.transform.Find("Plus/Button");
            if (buttonTransform != null)
            {
                Button buttonComponent = buttonTransform.GetComponent<Button>();
                if (buttonComponent != null)
                {
                    buttonComponent.onClick.AddListener(() => economyController.AddExpense(expenseModel.Id, 10));
                }
            }

            buttonTransform = itemObject.transform.Find("Minus/Button");
            if (buttonTransform != null)
            {
                Button buttonComponent = buttonTransform.GetComponent<Button>();
                if (buttonComponent != null)
                {
                    buttonComponent.onClick.AddListener(() => economyController.ReduceExpense(expenseModel.Id, 10));
                }
            }
        }
    }

    private void ShowSummary()
    {
        //� ����������
        EconomyController economyController = Context.GetItem<EconomyController>();
        // ������� ����� ��������
        for (byte i = 0; i < 3; i++)
        {
            GameObject itemObject = Instantiate(_itemSummaryPrefab, _scrollContent);

            Transform textTransform = itemObject.transform.Find("Category/Name");
            if (textTransform != null)
            {
                TextMeshProUGUI textComponent = textTransform.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    string text = "�����";
                    if (i == 1)
                    {
                        text = "������";
                    } else if (i == 2)
                    {
                        text = "������";
                    }
                    
                    textComponent.text = text;
                }
            }

            textTransform = itemObject.transform.Find("Value/Value");
            if (textTransform != null)
            {
                TextMeshProUGUI textComponent = textTransform.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    float value = economyController.getIncome();
                    if (i == 1)
                    {
                        value = economyController.getExpense();
                    } else if (i == 2)
                    {
                        value = economyController.getProfit();
                    }
                    textComponent.text = value.ToString() + " ���.";
                }
            }
        }
    }
}
