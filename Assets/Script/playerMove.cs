using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on " + gameObject.name);
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (rb != null)
        {
            Vector3 move = new Vector3(moveX, 0, moveZ) * speed;
            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        }
    }
}
