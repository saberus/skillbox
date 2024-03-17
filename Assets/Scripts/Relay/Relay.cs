using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//Change just to test the branch
public class Relay : MonoBehaviour
{
    [SerializeField] GameObject _target = null;
    [SerializeField] Runner _runner = null;
    [SerializeField] int _listSize = 0;
    
    Vector3[] _targetPositions;
    int _locationIndex = 0;
    bool _isForward = false;

    private void Awake()
    {
        _targetPositions = new Vector3[_listSize];
        PlaceTargets();
        _isForward = true;
        _runner.SetDestination(GetNextPosition(_locationIndex));
    }

    private void Update()
    {
        if (_targetPositions.Length <= 0) return;
        Run();
    }

    private void Run()
    {
        Vector3 currentTarget = _runner.GetDestination();
        if (_runner.transform.position == currentTarget)
        {
            _locationIndex = GetNextIndex();
            _runner.SetDestination(GetNextPosition(_locationIndex));
            if (IsSwitchDirection(currentTarget)) _isForward = !_isForward;
        }
    }

    private int GetNextIndex()
    {
        return _isForward ? _locationIndex + 1 : _locationIndex - 1;
    }

    private Vector3 GetNextPosition(int currentIndex)
    {
        if (_targetPositions.Length > currentIndex)
        {
            return _targetPositions[currentIndex];
        }
        else
        {
            return _targetPositions[0];
        }
    }

    private bool IsSwitchDirection(Vector3 currentTarget)
    {
        if(_locationIndex == _targetPositions.Length - 1 || _locationIndex == 0)
        {
            return true;
        }
        return false;
    }

    private void PlaceTargets()
    {
        
        for(int i = 0; i < _listSize; i++)
        {
            _targetPositions[i].Set(5*i,0,5*i); //ignore y to move only in y plane
            Instantiate(_target, _targetPositions[i], Quaternion.identity);
        }
    }
}
