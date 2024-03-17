using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//Change just to test the branch
public class Relay : MonoBehaviour
{
    [SerializeField] GameObject _target = null;
    [SerializeField] GameObject _runner = null;
    [SerializeField] int _listSize = 0;
    
    Vector3[] _targetPositions;
    int _locationIndex = 0;

    private void Awake()
    {
        _targetPositions = new Vector3[_listSize];
        PlaceTargets();
    }

    private void Update()
    {
        if (_targetPositions.Length <= 0) return;
        Run();
    }

    private void Run()
    {
        Vector3 currentTarget = GetNextPosition(_locationIndex);
        if (_runner.transform.position == currentTarget)
        {
            _locationIndex++;
            currentTarget = GetNextPosition(_locationIndex);
            _runner.transform.LookAt(currentTarget);
        }
        MoveRunner(currentTarget);
    }

    private void MoveRunner(Vector3 destination)
    {
        if(destination == null) return;
        _runner.transform.position = Vector3.MoveTowards(_runner.transform.position, destination, Time.deltaTime);
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

    private void PlaceTargets()
    {
        
        for(int i = 0; i < _listSize; i++)
        {
            _targetPositions[i].Set(5*i,5*i,5*i);
            Instantiate(_target, _targetPositions[i], Quaternion.identity);
        }
    }
}
