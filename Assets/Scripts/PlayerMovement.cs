using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    

    public CharacterController Controller;
    public Transform Camera;

    public float speed = 9f;
    public float gravity = -10f;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public float jumpHeight = 2f;


    Vector3 velocity;
    bool isGrounded ;


    // Start is called before the first frame update
    void Start()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    // Update is called once per frame
    void Update()
    {
        
        
         
        MovePlayer();
        
        
        
    }


    public void MovePlayer()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector3 direction = new Vector3(x, 0f, z).normalized;

        Vector3 move = transform.right * x + transform.forward * z;
        
        //if(direction.magnitude >=0.1f)
        //{
          //  float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
            //float angle = 
            //transform.rotation = Quaternion.Euler(0f, TargetAngle, 0f);

            //Vector3 MoveDirection = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;
            //Controller.Move(MoveDirection * speed * Time.deltaTime);
        //}

        Controller.Move(move * speed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        Controller.Move(velocity * Time.deltaTime);


    }


    


}
