using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isSprinting = false;
    public float sprintingSpeed;

    public bool isCrouching = false;
    public float standHeight = 1.85f;
    public float crouchHeight = 1.25f;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Normal Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; 

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded) //Jumping
        {
            velocity.y = Mathf.Sqrt(jumpHeight + -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift)) //Sprinting
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if(isSprinting == true)
        {
            controller.Move(move * sprintingSpeed * Time.deltaTime);
            CameraShaker.Instance.ShakeOnce(0.8f, 0.8f, -0.5f, 0.5f);
        }

        if (Input.GetKey(KeyCode.C)) //Crouching
        {
            isCrouching = true;
        }
        else
        {
            controller.height = standHeight;
            isCrouching = false;
        }

        if (isCrouching == true)
        {
            controller.height = crouchHeight;            
        }
    }
}
