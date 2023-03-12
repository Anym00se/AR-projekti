using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    public float spinVelocity = 200f;
    float rotationFromStart = 0f;

    void FixedUpdate()
    {
        RaycastHit hit;

        rotationFromStart += Time.deltaTime * spinVelocity;

        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, hit.normal, Color.green);
            transform.LookAt(new Vector3(transform.position.x, transform.position.y, 1000f));
            transform.up = hit.normal;
            transform.Rotate(new Vector3(0f, rotationFromStart, 0f), Space.Self);
        }
    }
}
