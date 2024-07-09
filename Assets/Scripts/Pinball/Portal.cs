using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    Transform _ballTransform = null;

    private Vector3 _ballInitialPosition;

    private void Start()
    {
        _ballInitialPosition = _ballTransform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _ballTransform.position = _ballInitialPosition;
        }
    }

}
