using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    private CheckPoint[] _checkPoints;
    [SerializeField] private Transform validateCheckpoint;
    
    private void Start()
    {
        _checkPoints = GetComponentsInChildren<CheckPoint>();
    }
    internal CheckPoint GetLastCheckPointThatWasPassed()
    {
        return _checkPoints.Last(t => t.Passed);
    }
}
