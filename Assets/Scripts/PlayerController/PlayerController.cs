using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;

    private float horizontalInput;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;

        controller.SimpleMove(new Vector3(horizontalInput, 0, 0));
    }
}
