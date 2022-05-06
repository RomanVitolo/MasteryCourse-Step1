using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using Random = UnityEngine.Random;


public class CoinBox : MonoBehaviour
{
    [SerializeField] SpriteRenderer _enabledSprite, _disabledSprite;
    [SerializeField] int totalCoins = 5;
    
    Animator _animator;
    private string[] _Clips = new string[] {"FlipCoin", "FlipCoin_2", "FlipCoin_3"};
    
    int remainingCoins;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        remainingCoins = totalCoins;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.contacts[0].normal);
        var randomClips = _Clips[Random.Range(0, _Clips.Length)];
        
        if (remainingCoins > 0 && WasHitByPlayer(other) && WasHiyFromBottomSide(other))
        {
            _animator.SetTrigger(randomClips);
            GameManager.Instance.CoinCollected();
            remainingCoins--;

            if (remainingCoins <= 0)
            {
                _enabledSprite.enabled = false;
                _disabledSprite.enabled = true;
            }
        }
    }

    private bool WasHitByPlayer(Collision2D other)
    {
        return other.collider.GetComponent<AgentController>() != null;
    }

    private bool WasHiyFromBottomSide(Collision2D other)
    {
        return other.contacts[0].normal.y > 0.5f;
    }
}
