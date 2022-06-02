using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
public class UICoinsText : MonoBehaviour
{
    TextMeshProUGUI _textmpro;
    private void Awake()
    {
        _textmpro = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        GameManager.Instance.OnCoinsChanged += HandleCoinsChanged;
    }

    private void HandleCoinsChanged(int _coins)
    {
        _textmpro.text = _coins.ToString();
    }
}
