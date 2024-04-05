using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroG : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb == null) return;
        rb.useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb == null) return;
        rb.useGravity = true;
    }

}
