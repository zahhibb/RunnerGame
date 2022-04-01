using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFollow : MonoBehaviour
{
    public Transform followTarget;
    private float damping = 1f;

    [SerializeField] private float movementSpeed = 1f;

    void Update()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, followTarget.position, step);

        LookAtDirection();
    }

    private void LookAtDirection()
    {
        var lookPos = followTarget.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}
