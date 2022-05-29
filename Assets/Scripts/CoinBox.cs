using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class CoinBox : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enabledSprite;
    [SerializeField] private SpriteRenderer _disabledSprite;
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
        var randomClips = _Clips[Random.Range(0, _Clips.Length)];
        
        if (remainingCoins > 0 && other.WasHitByPlayer() && other.WasHitFromBottomSide())
        {
            _animator.SetTrigger(randomClips);
            GameManager.Instance.CoinCollected();
            remainingCoins--;
            Debug.Log(randomClips);

            if (remainingCoins <= 0)
            {
                _enabledSprite.enabled = false;
                _disabledSprite.enabled = true;
            }
        }
    }
}
