using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdollCollision : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToRagdoll;
    [SerializeField] private bool startRagdoll = false;
    public bool StartRagdoll
    {
        get { return startRagdoll; }
        set { startRagdoll = value; }
    }

    void Update()
    {
        if (startRagdoll)
        {
            ModifyDetachedChildren();
        }
    }

    private void ModifyDetachedChildren()
    {
        for (int i = 0; i < objectsToRagdoll.Count; i++)
        {
            SetupColliders(i);
            SetupRigidbody(i);
        }
        transform.DetachChildren();
    }

    private void SetupColliders(int index)
    {
        if (objectsToRagdoll[index].GetComponent<BoxCollider>() == null)
        {
            if (objectsToRagdoll[index].GetComponent<SphereCollider>() != null) return;

            objectsToRagdoll[index].AddComponent<BoxCollider>();
        }
        else
        {
            objectsToRagdoll[index].GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void SetupRigidbody(int index)
    {
        if (objectsToRagdoll[index].GetComponent<Rigidbody>() == null)
        {
            objectsToRagdoll[index].AddComponent<Rigidbody>();
            objectsToRagdoll[index].GetComponent<Rigidbody>().mass = 10f;
            objectsToRagdoll[index].GetComponent<Rigidbody>().drag = 2f;
            objectsToRagdoll[index].GetComponent<Rigidbody>().angularDrag = 0.5f;
        }
    }
}
