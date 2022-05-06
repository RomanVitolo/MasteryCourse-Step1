using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    private CheckPoint[] _checkPoints;
    
    private void Start()
    {
        _checkPoints = GetComponentsInChildren<CheckPoint>();
    }
    internal CheckPoint GetLastCheckPointThatWasPassed()
    {
        return _checkPoints.Last(t => t.Passed);   //Devuelve el Ultimo Checkpoint por el que paso el player. El ultimo checkpoint del Array
    }
}
