using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameInterfaceUIView : MonoBehaviour
{
    public UnityEvent NextStep = new UnityEvent();

    public bool IsInitialized { get; private set; }

    public Context Context { get; private set; }

    public TMP_Text Date { get { return _date; } }
    public TMP_Text MoneyValue { get { return _moneyValue; } }
    public TMP_Text MoneyChangeValue { get { return _moneyChangeValue; } }
    public TMP_Text PopulationValue { get { return _populationValue; } }
    public TMP_Text PopulationChangeValue { get { return _populationChangeValue; } }
    public TMP_Text SupportValue { get { return _supportValue; } }
    public TMP_Text SupportChangeValue { get { return _supportChangeValue; } }
    public TMP_Text MobilizationReserveValue { get { return _mobilizationReserveValue; } }
    public TMP_Text MobilizationReserveChangeValue { get { return _mobilizationReserveChangeValue; } }
    public TMP_Text TradeBalanceValue { get { return _tradeBalanceValue; } }
    public TMP_Text TradeBalanceChangeValue { get { return _tradeBalanceChangeValue; } }
    public TMP_Text StabilityValue { get { return _stabilityValue; } }
    public TMP_Text StabilityChangeValue { get { return _stabilityChangeValue; } }


    public Button NextStepButton { get { return _nextStepButton; } }

    [SerializeField] private TMP_Text _date;
    [SerializeField] private TMP_Text _moneyValue;
    [SerializeField] private TMP_Text _moneyChangeValue;
    [SerializeField] private TMP_Text _populationValue;
    [SerializeField] private TMP_Text _populationChangeValue;
    [SerializeField] private TMP_Text _supportValue;
    [SerializeField] private TMP_Text _supportChangeValue;
    [SerializeField] private TMP_Text _mobilizationReserveValue;
    [SerializeField] private TMP_Text _mobilizationReserveChangeValue;
    [SerializeField] private TMP_Text _tradeBalanceValue;
    [SerializeField] private TMP_Text _tradeBalanceChangeValue;
    [SerializeField] private TMP_Text _stabilityValue;
    [SerializeField] private TMP_Text _stabilityChangeValue;

    [SerializeField] private Button _nextStepButton;

    [SerializeField] private GameObject _economyPanel;

    public void Initialize(Context context)
    {
        if (!IsInitialized)
        {
            IsInitialized = true;
            Context = context;
            /*
            _aInputField.onValueChanged.AddListener(AnyInputField_OnValueChanged);
            _addButton.onClick.AddListener(AddButton_OnClicked);
            */
            _nextStepButton.onClick.AddListener(NextStepButton_OnClicked);

            /*_date;
            _moneyValue;
            _moneyChangeValue;
            _populationValue;
            _populationChangeValue;
            _supportValue;
            _supportChangeValue;
            _mobilizationReserveValue;
            _mobilizationReserveChangeValue;
            _tradeBalanceValue;
            _tradeBalanceChangeValue;
            _stabilityValue;
            _stabilityChangeValue;*/


            //DI-контейнер
            PointsModel pointsModel = Context.GetItem<PointsModel>();
            DateModel dateModel = Context.GetItem<DateModel>();

            //Подписка на поле Money в модели PointsModel
            pointsModel.Money.AddListener((previousValue, newValue) =>
            {
                _moneyValue.text = ConvertMoneyToString(newValue); // Обновляем текстовое поле
                _moneyChangeValue.text = ConvertChangeMoneyToString(newValue - previousValue);
            });

            dateModel.CurrentDate.AddListener((previousValue, newValue) =>
            {
                _date.text = newValue;
            });
        }
    }

    private void NextStepButton_OnClicked() 
    {
        NextStep.Invoke();
    }

    private string ConvertMoneyToString(float money)
    {
        return money.ToString() + " млн.";
    }

    private string ConvertChangeMoneyToString(float moneyChange)
    {
        string result = moneyChange.ToString() + " млн.";
        if (moneyChange >= 0)
        {
            return "+ " + result;
        }
        return result;
    }
}
