using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] private float forwardMovementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 20f;

    private Vector3 movement;
    private Vector2 movementClampPositions = new Vector2(-7f, 7f);
    private float accelerationSpeed = 2f;
    private float maxSpeed;
    private float currentSpeed = 0;
    private bool beginRampingMovement = false;
    private bool hasDied = false;

    private Vector3 previousRecordedPosition = Vector3.zero;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        maxSpeed = movementSpeed;
        // InvokeRepeating();
    }

    void Update()
    {
        // input
        movement = new Vector3(Input.GetAxis("Horizontal") * 2, 0, forwardMovementSpeed);
    }

    void FixedUpdate()
    {
        // movement
        controller.transform.position = ClampedMovement();

        // rotation
        transform.GetChild(0).rotation = FaceTowardsMovementDirection(movement);
    }

    // private Vector3 RecordMovement(){

    // }

    private Vector3 ClampedMovement()
    {
        if (beginRampingMovement)
        {
            RampingMovement();
        }
        else
        {
            controller.Move(movement * movementSpeed * Time.deltaTime);
        }

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, movementClampPositions[0], movementClampPositions[1]);
        return clampedPosition;
    }

    private void RampingMovement()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed = currentSpeed + accelerationSpeed * Time.deltaTime;
        }
        else
        {
            beginRampingMovement = false;
            currentSpeed = 0;
        }
        controller.Move(movement * currentSpeed * Time.deltaTime);
    }

    private Quaternion FaceTowardsMovementDirection(Vector3 direction)
    {
        if (movement != Vector3.zero)
        {
            return Quaternion.Slerp(
                transform.GetChild(0).rotation,
                Quaternion.LookRotation(movement),
                Time.deltaTime * rotationSpeed
            );
        }
        return Quaternion.identity;
    }

    /// <summary>
    /// Enables/Disables player Movement and Graphic based on incoming bool value.
    /// </summary>
    private void SetPlayerState(bool incomingState)
    {
        transform.GetChild(0).gameObject.SetActive(incomingState);
        controller.enabled = incomingState;
        GetComponent<PlayerController>().enabled = incomingState;
    }



    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            SetPlayerState(false);
        }
    }
}