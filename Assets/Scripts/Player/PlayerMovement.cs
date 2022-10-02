using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 3000;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform grondCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public bool ladderControls = false;
    public float ladderSpeed = 0.1f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(grondCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (ladderControls == false)
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            if (!isGrounded)
            {
                Vector3 LadderMove = transform.right * x + transform.up * z;

                controller.Move(LadderMove * ladderSpeed * Time.deltaTime);
            }
            else
            {
                if (z >= 0)
                {
                    Vector3 LadderMove = transform.right * x + transform.up * z;

                    controller.Move(LadderMove * ladderSpeed * Time.deltaTime);
                }
                else if (z <= 0)
                {
                    Vector3 LadderMove = transform.right * x + transform.forward * z;

                    controller.Move(LadderMove * ladderSpeed * Time.deltaTime);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            ladderControls = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            ladderControls = false;

        }
    }
}
