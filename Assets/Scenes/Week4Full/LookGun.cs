using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookGun : MonoBehaviour
{
    private Vector3 NKey;
    private Vector3 MKey;
    private void Start()
    {
        NKey = new Vector3(0,-.1f,0);
        MKey = new Vector3(0, .1f, 0);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            transform.Rotate(NKey,Space.Self);
        }
        if (Input.GetKey(KeyCode.M))
        {
            transform.Rotate(MKey,Space.Self);
        }
    }
}
