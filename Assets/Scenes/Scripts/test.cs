using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10f;

        float vertical = Input.GetAxis("Vertical") * speed;
        float horizontal = Input.GetAxis("Horizontal") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        vertical *= Time.deltaTime;
        horizontal *= Time.deltaTime; 

        transform.Translate(horizontal, vertical, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "brownBox")
        {
            Debug.Log("brown box");
        }
        if (collision.gameObject.tag == "wall")
        {
            Debug.Log("Wall");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            Debug.Log("Wall");
        
    }
}
