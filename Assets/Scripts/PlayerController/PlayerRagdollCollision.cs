using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdollCollision : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToRagdoll;
    // [SerializeField] private Transform parentGameobject;

    [SerializeField] private bool startRagdoll = false;

    void Start()
    {

    }

    void Update()
    {
        if (startRagdoll)
        {
            // DetachChildrenIterative(transform);
            DetachChildrenIterative2();
        }
    }

    private void DetachChildrenIterative2()
    {
        for (int i = 0; i < objectsToRagdoll.Count; i++)
        {
            if (objectsToRagdoll[i].GetComponent<BoxCollider>() == null)
            {
                if (objectsToRagdoll[i].GetComponent<SphereCollider>() != null) return;

                objectsToRagdoll[i].AddComponent<BoxCollider>();
            }
            else
            {
                objectsToRagdoll[i].GetComponent<BoxCollider>().enabled = true;
            }

            if (objectsToRagdoll[i].GetComponent<Rigidbody>() == null)
            {
                objectsToRagdoll[i].AddComponent<Rigidbody>();
            }
        }
        transform.DetachChildren();
    }

    // private void DetachChildrenIterative(Transform parent)
    // {
    //     foreach (Transform child in parent)
    //     {
    //         if (child.gameObject.GetComponent<BoxCollider>() != null)
    //         {
    //             child.gameObject.GetComponent<BoxCollider>().enabled = true;
    //         }
    //         else
    //         {
    //             child.gameObject.AddComponent<BoxCollider>();
    //         }
    //         child.gameObject.AddComponent<Rigidbody>();
    //         // child.DetachChildren();
    //         // parent.DetachChildren();

    //         DetachChildrenIterative(child);
    //     }
    // }
}
