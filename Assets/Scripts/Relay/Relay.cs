using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Relay : MonoBehaviour
{
    [SerializeField] GameObject _targetGameObject = null;
    [SerializeField] GameObject _runnerGameObject = null;
    [SerializeField] int _listSize = 0;
    [SerializeField] float _passDistance = 2f;

    GameObject[] _runners = null;
    Runner _currentRunner = null;
    Vector3[] _targetPositions;
    int _locationIndex = 0;
    bool _isForward = false;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if (_targetPositions.Length <= 0) return;
        Run();
    }

    private void Run()
    {
        Vector3 currentTarget = _currentRunner.GetDestination();
        if (Vector3.Distance(_currentRunner.transform.position, currentTarget) <= _passDistance)
        {
            _currentRunner.ToggleMove();
            _locationIndex = GetNextIndex();
            _currentRunner = _runners[0].GetComponent<Runner>();
            _currentRunner.SetDestination(GetNextPosition(_locationIndex));
            _currentRunner.ToggleMove();
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
            _targetPositions[i].Set(10*i,0,10*i); //ignore y
            Instantiate(_targetGameObject, _targetPositions[i], Quaternion.identity);
            _runners[i] = Instantiate(_runnerGameObject, _targetPositions[i], Quaternion.identity);
        }
    }

    private void Initialize()
    {
        _targetPositions = new Vector3[_listSize];
        _runners = new GameObject[_listSize];
        PlaceTargets();
        _isForward = true;
        _currentRunner = _runners[0].GetComponent<Runner>();
        _currentRunner.SetDestination(GetNextPosition(_locationIndex));
        _currentRunner.ToggleMove();
    }
}
