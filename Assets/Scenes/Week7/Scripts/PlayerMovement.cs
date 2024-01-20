using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _07_LEVELCONTROLLER;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private float speed = 3f;
    private float horizontalSpeed = 4f;

    private void FixedUpdate()
    {
        transform.Translate((Vector3.forward) * speed * Time.fixedDeltaTime, Space.World);

        if(Input.touchCount > 0)
        {
            //A
            {
                if(this.gameObject.transform.position.x > _07_LEVELCONTROLLER.LevelController.leftSide)
                    transform.Translate((Vector3.left) * Time.fixedDeltaTime * horizontalSpeed, Space.World);
            }
            //D
            {
                if (this.gameObject.transform.position.x > _07_LEVELCONTROLLER.LevelController.rightSide)
                    transform.Translate((Vector3.left) * Time.fixedDeltaTime * horizontalSpeed, Space.World);
            }
        }
    }
}
