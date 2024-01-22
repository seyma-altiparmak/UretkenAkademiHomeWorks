using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _07_LEVELCONTROLLER;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private float speed = 3f;
    private float horizontalSpeed = 4f;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;

    private void FixedUpdate()
    {
        transform.Translate((Vector3.forward) * speed * Time.fixedDeltaTime, Space.World);
        if (canMove == true)
        {
            if (Input.touchCount > 0)
            {
                //A
                {
                    if (this.gameObject.transform.position.x > _07_LEVELCONTROLLER.LevelController.leftSide)
                        transform.Translate((Vector3.left) * Time.fixedDeltaTime * horizontalSpeed, Space.World);
                }
                //D
                {
                    if (this.gameObject.transform.position.x > _07_LEVELCONTROLLER.LevelController.rightSide)
                        transform.Translate((Vector3.left) * Time.fixedDeltaTime * horizontalSpeed, Space.World);
                }
                //jumpbutton
                {
                    if (!isJumping)
                    {
                        isJumping = true;
                        playerObject.GetComponent<Animator>().Play("Jump");
                        StartCoroutine(JumpSequence());
                    }
                }
            }
            if (isJumping)
            {
                if (!comingDown)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
                }
                if (comingDown)
                {
                    transform.Translate(Vector3.up * Time.deltaTime *-3, Space.World);
                }
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Run");
    }
}
