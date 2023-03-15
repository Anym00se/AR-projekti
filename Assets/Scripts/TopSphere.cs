using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSphere : MonoBehaviour
{
    public float impulse = 2f;
    private float pushDelay = 0f;

    void Update()
    {
        pushDelay -= Time.deltaTime;
        if (pushDelay < 0f) { pushDelay = 0f; }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<TopSphere>() && pushDelay <= 0f)
        {
            pushDelay = 0.2f;
            collision.collider.gameObject.GetComponent<Rigidbody>().AddForce(
                -(collision.collider.gameObject.transform.position - transform.position).normalized * impulse,
                ForceMode.Impulse
            );
        }
    }
}
