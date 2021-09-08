using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
    private Rigidbody thisRb;
    private Transform thisTransform;

    private void Start()
    {
        thisTransform = transform;
        thisRb = GetComponent<Rigidbody>();
    }

    public void OnParticleCollision(GameObject collision)
    {
        thisTransform.parent = null;
        thisRb.isKinematic = false;
    }
}
