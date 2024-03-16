using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Relay : MonoBehaviour
{
    [SerializeField] GameObject _target = null;
    [SerializeField] GameObject _runner = null;
    [SerializeField] int _listSize = 0;
    
    Vector3[] _targetLocations;

    private void Awake()
    {
        _targetLocations = new Vector3[_listSize];
        PlaceTargets();
    }

    private void Update()
    {
        MoveRunner();
    }

    private void MoveRunner()
    {
        
    }

    private void PlaceTargets()
    {
        
        for(int i = 0; i < _listSize; i++)
        {
            _targetLocations[i].Set(1+i,1+i,1+i);
            Instantiate(_target, _targetLocations[i], Quaternion.identity);
        }
    }
}
