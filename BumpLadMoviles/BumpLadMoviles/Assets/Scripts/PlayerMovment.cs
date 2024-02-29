using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public float speed;
    public Rigidbody2D body;
    float dx;
    float dy;
    private GameUI GUI;

    void Start()
    {
        GUI = FindObjectOfType<GameUI>();
        Input.gyro.enabled = true;
    }

    public void Update()
    {
        dx = Input.acceleration.x * speed * Time.deltaTime;
        //dy = Input.acceleration.y * speed * Time.deltaTime;
        transform.position = new Vector2 (Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(dx, 0f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Car"))
        {
            GUI.Defeat();
           
        }
    }
}


