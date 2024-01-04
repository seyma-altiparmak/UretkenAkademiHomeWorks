using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarternionTeker : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.right,speed);
    }
}
