using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdollCollision : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToRagdoll;
    private bool startRagdoll = false;
    private bool hasExploded = false;
    public bool StartRagdoll
    {
        get { return startRagdoll; }
        set { startRagdoll = value; }
    }

    [Header("Rigidbody data")]
    [SerializeField] private float rigidbodyMass = 10f;
    [SerializeField] private float rigidbodyDrag = 2f;
    [SerializeField] private float rigidbodyAngularDrag = 0.5f;
    [SerializeField] private float rigidbodyExplosionForce = 10f;
    [SerializeField] private float rigidbodyExplosionRadius = 3f;

    void Update()
    {
        if (startRagdoll)
        {
            ModifyDetachedChildren();

            if (!hasExploded)
                ExplosionForce();
        }
    }

    private void ExplosionForce()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, rigidbodyExplosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(rigidbodyExplosionForce, explosionPos, rigidbodyExplosionRadius, 3.0F, ForceMode.Impulse);
        }
        hasExploded = true;
    }

    private void ModifyDetachedChildren()
    {
        for (int i = 0; i < objectsToRagdoll.Count; i++)
        {
            if (objectsToRagdoll[i] == null) return;

            SetupColliders(i);
            SetupRigidbody(i);
        }
        transform.DetachChildren();
    }

    private void SetupColliders(int index)
    {
        if (objectsToRagdoll[index].GetComponent<CapsuleCollider>() != null)
            objectsToRagdoll[index].GetComponent<CapsuleCollider>().enabled = true;

        if (objectsToRagdoll[index].GetComponent<BoxCollider>() == null)
        {
            if (objectsToRagdoll[index].GetComponent<CapsuleCollider>() == null)
            {
                objectsToRagdoll[index].AddComponent<BoxCollider>();
            }
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
            objectsToRagdoll[index].GetComponent<Rigidbody>().mass = rigidbodyMass;
            objectsToRagdoll[index].GetComponent<Rigidbody>().drag = rigidbodyDrag;
            objectsToRagdoll[index].GetComponent<Rigidbody>().angularDrag = rigidbodyAngularDrag;
        }
    }

    public void CleanUpObjects()
    {
        for (int i = 0; i < objectsToRagdoll.Count; i++)
        {
            Destroy(objectsToRagdoll[i].gameObject);
        }
    }
}
