using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSphere : MonoBehaviour
{
    public float impulse = 2f;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<TopSphere>())
        {
            Debug.Log("Collision");
            collision.collider.gameObject.GetComponent<Rigidbody>().AddForce(
                -(collision.collider.gameObject.transform.position - transform.position).normalized * impulse,
                ForceMode.Impulse
            );
        }
    }
}
