using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveController : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 1.8f;
    private bool isMove;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) isMove = true;
        else isMove = false;

        if (isMove)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(dikey, 0, yatay);
            rb.AddForce(direction * speed);

        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void FixedUpdate()
    {
        //LookingCMR();
    }

    void LookingCMR()
    {
        // Mouse'un bulunduðu yöne dönme
        if (Camera.main != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(targetPosition);
            }
        }
    }
}
