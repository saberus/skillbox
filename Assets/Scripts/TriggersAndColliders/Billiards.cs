using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billiards : MonoBehaviour
{
    [SerializeField] float _forceAmount = 0;
    private Rigidbody _rigidbody = null;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _rigidbody.AddForce(new Vector3(0, 0, _forceAmount) ,ForceMode.Impulse);
    }

}
