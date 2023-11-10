using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public Transform bg;
    public SpriteRenderer grid;
    public Transform Cam;

    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        bg.position = Player.instance.transform.position;
        Cam.position = Player.instance.transform.position;
        UpdateBgGrid();
    }
    private void UpdateBgGrid()
    {
        grid.size += Player.instance.rb.velocity / 50f;
        if (grid.size.x > 40)
        {
            grid.size += new Vector2(-2, 0);
        }
        if (grid.size.x < 30)
        {
            grid.size += new Vector2(2, 0);
        }
        if (grid.size.y > 35)
        {
            grid.size += new Vector2(0, -2);
        }
        if (grid.size.y < 25)
        {
            grid.size += new Vector2(0, 2);
        }
    }
    public static Vector2 GetVector(float angle) //angle to V2
    {
        Vector2 correct = Vector2.zero;
        correct.x = Mathf.Cos((angle) * Mathf.Deg2Rad);
        correct.y = Mathf.Sin((angle) * Mathf.Deg2Rad);

        return correct.normalized;
    }
}