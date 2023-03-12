using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    Rigidbody rb;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        rb.angularVelocity = new Vector3(0f, 20f, 0f);
    }
}
