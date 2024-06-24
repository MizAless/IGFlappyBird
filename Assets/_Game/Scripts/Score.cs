using AppsFlyerSDK;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BestScore))]
public class Score : MonoBehaviour
{
    private int _value = 0;

    private BestScore _bestScore;

    public event Action<int> Changed;

    private void Awake()
    {
        _bestScore = GetComponent<BestScore>();
    }

    public void Add()
    {
        _value++;
        _bestScore.TryUpdateValue(_value);
        Changed?.Invoke(_value);
    }
}
