using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bumper : MonoBehaviour
{
    [SerializeField]
    float _speed = 5f;
    [SerializeField]
    float _distance = 0.5f;
    void Update()
    {
        Vector3 pos = transform.localPosition;
        float newZ = Mathf.Sin(Time.time * _speed);
        transform.localPosition = new Vector3(pos.x, pos.y, newZ) * _distance;
    }
}
