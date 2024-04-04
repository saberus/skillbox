using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float _radius = 0;
    [SerializeField] float _power = 0;

    private float _timeToExplode = 0.5f;

    private void Update()
    {
        _timeToExplode -= Time.deltaTime;
        if( _timeToExplode < 0)
        {
            Explode();
            _timeToExplode = 10f;
        }
    }

    private void Explode()
    {
        Rigidbody[] bodies = FindObjectsOfType<Rigidbody>();
        print(bodies.Length);
        foreach (Rigidbody b in bodies)
        {
            float distance = Vector3.Distance(transform.position, b.transform.position);
            if (distance < _radius)
            {
                Vector3 direction = (b.transform.position - transform.position).normalized;
                b.AddForce(direction * _power * (_radius - distance), ForceMode.Impulse);
            }
        }
    }
}
