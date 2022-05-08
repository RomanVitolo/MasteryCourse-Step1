using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
   AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += PlayAudioCoin;
    }
    
    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= PlayAudioCoin;
    }
    
    private void PlayAudioCoin(int coins)
    {
        _audioSource.Play();
    }
}
