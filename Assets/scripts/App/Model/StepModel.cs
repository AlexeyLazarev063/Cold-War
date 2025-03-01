using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepModel
{
    public bool IsInitialized { get; private set; }

    public Context Context { get; private set; }

    public short StepNumber { get { return _stepNumber; } }
    private short _stepNumber;

    public void Initialize(Context context)
    {
        IsInitialized = true;
        Context = context;
        _stepNumber = 1;
    }

    public void AddStep()
    {
        _stepNumber++;
    }
}
