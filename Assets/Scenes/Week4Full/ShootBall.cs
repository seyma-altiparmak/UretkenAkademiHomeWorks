using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    private GameObject shootPoint;

    private void Awake()
    {
        shootPoint = GameObject.Find("ShootPoint");
        if (shootPoint != null) print("shootpoint detected.");
    }

}
