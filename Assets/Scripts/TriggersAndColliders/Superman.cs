using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{

    [SerializeField] float _forceAmount = 0;

    Rigidbody _rb = null;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            print("Contact");
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
            _rb.AddForce(Vector3.left);
        if (Input.GetKey(KeyCode.D))
            _rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.W))
            _rb.AddForce(Vector3.forward);
        if (Input.GetKey(KeyCode.S))
            _rb.AddForce(Vector3.back);
    }
}
