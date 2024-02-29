using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovment : MonoBehaviour
{
    public float speed;
    public float startY;
    public float limitY;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        if (transform.position.y <= limitY)
        {
            transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        }
    }
}
