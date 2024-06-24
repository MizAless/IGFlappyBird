using System;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    private const string SavePropertyName = nameof(BestScore);

    private int _value;

    public int Value => _value;

    public event Action<int> Changed;

    private void Awake()
    {
        _value = PlayerPrefs.GetInt(SavePropertyName);
    }

    private void Start()
    {
        Changed?.Invoke(_value);
    }

    public void TryUpdateValue(int value)
    {
        if (value <= _value)
            return;

        _value = value;
        PlayerPrefs.SetInt(SavePropertyName, _value);
        print("new best score");
        Changed?.Invoke(_value);
    }
}
