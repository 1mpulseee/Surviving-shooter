using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float RotSpeed;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        rb.AddForce(new Vector2(H, V) * speed);

        transform.Rotate(new Vector3(0, 0, rb.velocity.x) * -RotSpeed);
    }
}
