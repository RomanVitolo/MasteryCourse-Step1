using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoinImage : MonoBehaviour
{
    Animator _animator;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
        //Esta vez lo instancio en el Start, para esperar los tiempos necesarios y que todo este en orden
        GameManager.Instance.OnCoinsChanged += Pulse;
    }

    private void Pulse(int coins) //Con este parametro podria hacer diferentes animaciones, llegado una X cantidad
    {
        _animator.SetTrigger("Pulse");
    }
}
