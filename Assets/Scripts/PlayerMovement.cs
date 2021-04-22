using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;
    public float gravity = 20f;

    CharacterController controller;

    Vector3 moveDirection = Vector3.zero;
    float horizontal;
    float vertical;

    public float jump = 8f;

    public float rotationspeed = 80f;
    public float rotation = 0f;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
                
            moveDirection = new Vector3(0, 0.0f, vertical) * speed;        // horizontal = 0
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jump;
            }

            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

        }

        rotation += Input.GetAxis("Horizontal") * rotationspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);



    }
}
