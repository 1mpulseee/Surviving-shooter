using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float speed;
    public float RotSpeed;

    [HideInInspector] public Rigidbody2D rb;

    public GameObject starObj; //submit to the manager
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Gun_star());
    }
    private void FixedUpdate()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        rb.AddForce(new Vector2(H, V) * speed);

        transform.Rotate(new Vector3(0, 0, rb.velocity.x) * -RotSpeed);
    }
    public IEnumerator Gun_star()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(Gun_star_move());
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(5);
        }
    }
    public IEnumerator Gun_star_move()
    {
        GameObject star = Instantiate(starObj, transform.position, Quaternion.identity); //do damage (upgrades)
        float angle = Random.Range(0, 360);
        float increasingAngle = 2.1f;
        float pos = 1f;
        for (int i = 0; i < 200; i++) //duration (upgrades)
        {
            Vector2 NewPos = Manager.GetVector(angle) * pos;
            star.transform.position = transform.position + new Vector3(NewPos.x, NewPos.y, 0);
            yield return new WaitForFixedUpdate();
            pos += 0.03f;
            angle += increasingAngle;
            increasingAngle += 0.017f;
        }
        //do explosion (upgrades)
        Destroy(star);
    }
}