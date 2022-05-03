using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Vector2 movement;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
      rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

    }


}
