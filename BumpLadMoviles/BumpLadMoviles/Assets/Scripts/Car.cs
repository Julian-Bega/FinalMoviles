using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed;
    public int state;

    private void Start()
    {
        state = 0;
    }
    void Update()
    {
        switch (state)
        {
            case 0:
                
                break;
            case 1:
                transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
                break;
            case 2:
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
                break;

            default:
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Car") && state != 0)
        {
            float auxSpeed = collision.gameObject.GetComponent<Car>().speed;
            state = 1;
            if (auxSpeed >= speed)
            {
                speed = auxSpeed;
            }
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            speed = 0;
            transform.position = new Vector3(15, 15, -1.0f);
            state = 0;
        }
    }


   
}
