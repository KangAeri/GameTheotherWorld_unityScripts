using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cityplayermov : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed = 6.0f;
    float movx, movy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movx = Input.GetAxis("Horizontal");
        //movy = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x = position.x + speed * movx * Time.deltaTime;
        //position.y = position.y + speed * movy * Time.deltaTime;

        rb.MovePosition(position);

        //rb.velocity = new Vector2(movx * speed* Time.deltaTime, movy * speed* Time.deltaTime);
    }
}
