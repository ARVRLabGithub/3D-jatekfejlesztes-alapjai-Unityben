using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //reveice input from InputManager and apply to character
    public void ProcessForwardBackWard(float input)
    {
        Vector3 moveDirection = Vector3.zero;
        if(input > 0)
        {
            moveDirection.y = input;
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        }
        else
        {
            moveDirection.y = -input;
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        }
        //moveDirection.z = input.y;
        //Console.WriteLine(input);
        
    }
    public void ProcessLeftRight(float input)
    {
        Vector3 moveDirection = Vector3.zero;
        if (input > 0)
        {
            moveDirection.x = input;
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        }
        else
        {
            moveDirection.x = -input;
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        }
        //moveDirection.z = input.y;
        //Console.WriteLine(input);

    }
    public void ProcessJump(float input)
    {
        Debug.Log("Jump");
        //moveDirection.z = input.y;
        //Console.WriteLine(input);

    }

}
