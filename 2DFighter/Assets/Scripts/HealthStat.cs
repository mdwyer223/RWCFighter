using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HealthStat {

    [SerializeField]
    private HealthBarScript bar;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float currVal;

    public float CurrVal
    {
        get
        {
            return currVal;
        }

        set
        {
            currVal = value;
            bar.Value = currVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            maxVal = value;
            bar.MaxVal = value;
        }
    }

    public void Initialize() {
        MaxVal = maxVal;
        CurrVal = currVal;
    }
}
