using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateModel
{
    public bool IsInitialized { get; private set; }

    public Context Context { get; private set; }

    public Observable<string> CurrentDate { get { return _currentDate; } }
    private Observable<string> _currentDate = new Observable<string>();

    const short _startYear = 1970;

    public void Initialize(Context context)
    {
        IsInitialized = true;

        Context = context;
        _currentDate.Value = "Янв. 1970";
    }

    public void NextDate(short _stepNumber)
    {
        short year = (short)(_startYear + _stepNumber / 12);
        string mouth = "Янв.";
        switch (_stepNumber % 12)
        {
            case 0:
                mouth = "Дек.";
                break;
            case 1:
                mouth = "Янв.";
                break;
            case 2:
                mouth = "Фев.";
                break;
            case 3:
                mouth = "Март";
                break;
            case 4:
                mouth = "Апр.";
                break;
            case 5:
                mouth = "Май";
                break;
            case 6:
                mouth = "Июнь";
                break;
            case 7:
                mouth = "Июль";
                break;
            case 8:
                mouth = "Авг.";
                break;
            case 9:
                mouth = "Сен.";
                break;
            case 10:
                mouth = "Окт.";
                break;
            case 11:
                mouth = "Нояб.";
                break;
        }
        _currentDate.Value = mouth + " " + year.ToString();
    }
}
