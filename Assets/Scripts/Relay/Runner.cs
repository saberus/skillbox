using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] float _speed = 1f;

    private Vector3 _destination;

    private void Update()
    {
        MoveRunner();
    }
    public void MoveRunner()
    {
        if (_destination == null) return;
        transform.position = Vector3.MoveTowards(transform.position, _destination, Time.deltaTime * _speed);
    }

    public Vector3 GetDestination()
    {
        return _destination;
    }

    public void SetDestination(Vector3 destination)
    {
        _destination = destination;
        transform.LookAt(destination);
    }

}
