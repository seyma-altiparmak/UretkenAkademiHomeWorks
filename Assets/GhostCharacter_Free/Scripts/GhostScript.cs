using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sample {
public class GhostScript : MonoBehaviour
{
        /*
        PlayerInput playerInput;
        InputAction moveAction;

        [SerializeField] float speed = 20f;

        private void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions.FindAction("Move");
        }

        private void Update()
        {
            MovePlayer();
        }

        void MovePlayer()
        {
            Vector2 direction = (moveAction.ReadValue<Vector2>());
            print(direction.x);
            print(direction.y);
            transform.position += new Vector3(direction.x, 0, direction.y) * Time.deltaTime * speed; 
        }*/
        /*
        public Camera playerCamera;
        public float walkSpeed = 6f;
        public float runSpeed = 12f;
        public float jumpPower = 7f;
        public float gravity = 10f;
        public float lookSpeed = 2f;
        public float lookXLimit = 45f;
        public float defaultHeight = 2f;
        public float crouchHeight = 1f;
        public float crouchSpeed = 3f;

        private Vector3 moveDirection = Vector3.zero
    ;
        private float rotationX = 0;
        private CharacterController characterController;
        private UIManager8 ui;

        private bool canMove = true;

        void Start()
        {
            characterController = GetComponent<CharacterController>();
            ui = GameObject.Find("UIController").GetComponent<UIManager8>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            if (ui.isActive)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);

                bool isRunning = Input.GetKey(KeyCode.LeftShift);
                float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
                float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
                float movementDirectionY = moveDirection.y;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);

                if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
                {
                    moveDirection.y = jumpPower;
                }
                else
                {
                    moveDirection.y = movementDirectionY;
                }

                if (!characterController.isGrounded)
                {
                    moveDirection.y -= gravity * Time.deltaTime;
                }

                if (Input.GetKey(KeyCode.R) && canMove)
                {
                    characterController.height = crouchHeight;
                    walkSpeed = crouchSpeed;
                    runSpeed = crouchSpeed;

                }
                else
                {
                    characterController.height = defaultHeight;
                    walkSpeed = 6f;
                    runSpeed = 12f;
                }

                characterController.Move(moveDirection * Time.deltaTime);

                if (canMove)
                {
                    rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                    rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                    playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                    transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
                }
            }
        }*/
    }
}