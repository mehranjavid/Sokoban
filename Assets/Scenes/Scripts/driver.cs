using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driver : MonoBehaviour
{
    bool keyPressed = false;  

    void Start()
    {
        
    }
     
    void Update()
    {
        //********************************************* Getting input from user ************************************

        if (Input.GetKeyDown(KeyCode.UpArrow)
             || Input.GetKeyDown(KeyCode.DownArrow)
             || Input.GetKeyDown(KeyCode.LeftArrow)
             || Input.GetKeyDown(KeyCode.RightArrow))
        {
            keyPressed = true; 
        }

        if (Input.GetAxis("Horizontal") > 0 && keyPressed) //right
        {
            Vector3 newposition = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            takeTransition(newposition);
        }
        else if (Input.GetAxis("Horizontal") < 0 && keyPressed) //left
        {
            Vector3 newposition = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            takeTransition(newposition);
        }
        else if (Input.GetAxis("Vertical") > 0 && keyPressed) //up
        {
            Vector3 newposition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            takeTransition(newposition);
        }
        else if (Input.GetAxis("Vertical") < 0 && keyPressed) //down
        {
            Vector3 newposition = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            takeTransition(newposition);
        }

        //*************************************************************************************************************

    }

    private void takeTransition(Vector3 newposition)
    {
        if (checkBox(newposition))
        {
            transform.position = newposition;
        }
        else if (!checkWall(newposition))
        {
            transform.position = newposition;
        }
        keyPressed = false;
    }

    private bool checkBox(Vector3 newposition)
    {
        GameObject [] boxes = GameObject.FindGameObjectsWithTag("brownBox");

        for (int i = 0; i < boxes.Length; i++)
        {
            if (boxes[i].transform.position == newposition)
            {
                Vector3 nextToBox = new Vector3(newposition.x + 1, newposition.y, newposition.z);
                if (!checkWall(nextToBox)) // no wall next to box?
                {
                    boxes[i].transform.position = nextToBox;
                }
            }
        }
        return false;
    }

    private bool checkWall(Vector3 newposition)
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("wall");
        for (int i = 0; i < boxes.Length; i++)
        {
            if (boxes[i].transform.position == newposition)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ground")
        {
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

/*
 

 



    if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        } 
*/
