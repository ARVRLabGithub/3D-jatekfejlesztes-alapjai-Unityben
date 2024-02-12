using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class UserCharachterMovement : MonoBehaviour
{
    private Vector3 PlayerVelocity;
    static public float Speed = 5f;
    public float gravity = -9.8f;
    public bool isGrounded;
    private CharacterController controller;
    public float jumpHeight = 3f;
    private Vector3 moveDirection = Vector3.zero;

    private float rotationX = 0f;
    private float rotationY = 0f;

    public float PlayerRotationSensitivity = 15f;

    private Transform cameraparentNode; 
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraparentNode = transform.Find("CameraHolder");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            print("Keyboard Press: SPACE");
            Jump();
        }
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W");
            controller.Move(transform.forward * Time.deltaTime * Speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
            controller.Move(-transform.forward * Time.deltaTime * Speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            controller.Move(transform.right * Time.deltaTime * Speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            controller.Move(-transform.right * Time.deltaTime * Speed);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cameraparentNode.transform.localPosition = new Vector3(0,-0.775f,0);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            cameraparentNode.transform.localPosition = new Vector3(0, 0, 0);
        }
        if (isGrounded && PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = -2.0f;
        }
        isGrounded = controller.isGrounded;
        PlayerVelocity.y += gravity * Time.deltaTime;
        controller.Move(PlayerVelocity * Time.deltaTime);

        rotationY += Input.GetAxis("Mouse X") * PlayerRotationSensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * PlayerRotationSensitivity;
        transform.localEulerAngles = new Vector3(rotationX,rotationY, 0);
    }

   
    public void Jump()
    {
        if (isGrounded)
        {
            PlayerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
