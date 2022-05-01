using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        GameManager.Instance.CoinCollected();
        Debug.Log(GameManager.Instance.coins);
    }
}
