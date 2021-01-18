using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyPlayer : MonoBehaviour
{
    public MyCharacterController Character;
    public PlayerCharacterInputs characterInputs;
    public Camera freeLookComponent;

    public Animator Anim;

    private const string MouseXInput = "Mouse X";
    private const string MouseYInput = "Mouse Y";
    private const string MouseScrollInput = "Mouse ScrollWheel";
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        characterInputs = new PlayerCharacterInputs
        {
            MoveAxisForward = 0.0f,
            JumpDown = false,
            CrouchDown = false,
            CrouchUp = false,
            CameraRotation = freeLookComponent.transform.rotation
        //InteractDown = false,
        //EscapeDown = false,
        //FireDown = false,
        };

    }

    private void FixedUpdate ()
    {
        characterInputs.CameraRotation = freeLookComponent.transform.rotation;
        Character.SetInputs(ref characterInputs);


    }

    public void OnJump(InputAction.CallbackContext value)
    {
        characterInputs.JumpDown = value.started;
        Character.SetInputs(ref characterInputs);
    }


    public void OnMovement(InputAction.CallbackContext value)
    {

        Vector2 inputMovement = value.ReadValue<Vector2>();
        characterInputs.MoveAxisForward = inputMovement.y;
        characterInputs.MoveAxisRight = inputMovement.x;
        
    }


    public void OnCrouch(InputAction.CallbackContext value)
    {
        characterInputs.CrouchDown = value.started;
        characterInputs.CrouchUp = value.canceled;
        Character.SetInputs(ref characterInputs);
    }


}
