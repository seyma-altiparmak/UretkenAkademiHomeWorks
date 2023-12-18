using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private Transform SunTransform;
    private TurnSelf turnself;
    private List<float> turnSpeed = new List<float>{4,3,2,2,1,0.9f,0.6f,0.5f };
    [SerializeField]
    private int selectedTurnSpeedIndex = 0;

    private bool IS_turnSelf = false;
    private void Start()
    {
        SunTransform = GameObject.Find("MainPoint").transform;
        if (gameObject.GetComponent<TurnSelf>())
        {
            this.turnself = gameObject.GetComponent<TurnSelf>();
            IS_turnSelf = true;
        }
    }
    void Turn()
    {
        if (IS_turnSelf)
        {
            transform.Rotate(Vector3.up, turnself.turnSpeed * Time.deltaTime);
        }
        if (SunTransform != null && transform.gameObject.name != "Sun")
        {
            transform.RotateAround(SunTransform.position,Vector3.up, turnSpeed[selectedTurnSpeedIndex]*Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        Turn();
    }
}
