using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput PlayerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerInput = new PlayerInput();
        onFoot = PlayerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("Message: "+onFoot.MovementLeftRight.ReadValue<float>());
        motor.ProcessForwardBackWard(onFoot.MovementForwardBackward.ReadValue<float>());
        motor.ProcessLeftRight(onFoot.MovementLeftRight.ReadValue<float>());
        motor.ProcessJump(onFoot.Jump.ReadValue<float>());
    }
    private void OnEnabled()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
