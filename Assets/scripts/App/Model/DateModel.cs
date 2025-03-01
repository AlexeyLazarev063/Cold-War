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
        _currentDate.Value = "���. 1970";
    }

    public void NextDate(short _stepNumber)
    {
        short year = (short)(_startYear + _stepNumber / 12);
        string mouth = "���.";
        switch (_stepNumber % 12)
        {
            case 0:
                mouth = "���.";
                break;
            case 1:
                mouth = "���.";
                break;
            case 2:
                mouth = "���.";
                break;
            case 3:
                mouth = "����";
                break;
            case 4:
                mouth = "���.";
                break;
            case 5:
                mouth = "���";
                break;
            case 6:
                mouth = "����";
                break;
            case 7:
                mouth = "����";
                break;
            case 8:
                mouth = "���.";
                break;
            case 9:
                mouth = "���.";
                break;
            case 10:
                mouth = "���.";
                break;
            case 11:
                mouth = "����.";
                break;
        }
        _currentDate.Value = mouth + " " + year.ToString();
    }
}
