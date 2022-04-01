using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetMovement : MonoBehaviour
{
    private CharacterController characterController;
    private float horizontalInput;

    [SerializeField] private float movementSpeed = 5f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, 0, movementSpeed);

        characterController.SimpleMove(move * movementSpeed * Time.deltaTime);
    }
}
