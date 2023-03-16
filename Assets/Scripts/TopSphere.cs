using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSphere : MonoBehaviour
{
    private float impulse = 1f;
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
                (collision.collider.gameObject.transform.position - transform.position + GetRandom_XZ_Vector()).normalized * impulse,
                ForceMode.Impulse
            );
        }
    }

    private Vector3 GetRandom_XZ_Vector()
    {
        return new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        );
    }
}
