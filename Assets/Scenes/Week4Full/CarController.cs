using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Vector3 inputController;
    private Vector3 hizController;
    void Start()
    {
        print("kodum baþladý");   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        inputController = new Vector3(moveHorizontal, 0, moveVertical);
        hizController += inputController * Time.fixedDeltaTime;
        transform.position += hizController;
    }
}
