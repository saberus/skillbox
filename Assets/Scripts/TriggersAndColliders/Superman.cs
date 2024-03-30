using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (rigidbody == null) return;
        Vector3 direction = (collision.transform.position - transform.position).normalized;
        rigidbody.AddForce(direction * _forceAmount, ForceMode.Impulse);
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
