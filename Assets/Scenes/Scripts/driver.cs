using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driver : MonoBehaviour
{
    bool keyPressed = false;  
     
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
            takeTransition(newposition, "right");
        }
        else if (Input.GetAxis("Horizontal") < 0 && keyPressed) //left
        {
            Vector3 newposition = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            takeTransition(newposition, "left");
        }
        else if (Input.GetAxis("Vertical") > 0 && keyPressed) //up
        {
            Vector3 newposition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            takeTransition(newposition, "up");
        }
        else if (Input.GetAxis("Vertical") < 0 && keyPressed) //down
        {
            Vector3 newposition = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            takeTransition(newposition, "down");
        }

        //*************************************************************************************************************
    }

    private void takeTransition(Vector3 newposition, string direction)
    {
        if (checkBox(newposition, direction))
        {
            transform.position = newposition;
        }
        else if (!checkWall(newposition) && keyPressed)
        {
            transform.position = newposition;
        }
        keyPressed = false;
    }

    private bool checkBox(Vector3 newposition , string direction)
    {
        GameObject [] boxes = GameObject.FindGameObjectsWithTag("brownBox");

        for (int i = 0; i < boxes.Length; i++)
        {
            if (boxes[i].transform.position == newposition)
            {
                Vector3 nextToBox;
                if (direction== "right")
                {
                    nextToBox = new Vector3(newposition.x + 1, newposition.y, newposition.z);
                    if (CheckWallBoxNext(boxes, boxes[i], nextToBox))
                    {
                        return true;
                    }
                }
                else if (direction == "left")
                {
                    nextToBox = new Vector3(newposition.x - 1, newposition.y, newposition.z);
                    if (CheckWallBoxNext(boxes, boxes[i], nextToBox))
                    {
                        return true;
                    }
                }
                else if (direction == "up")
                {
                    nextToBox = new Vector3(newposition.x , newposition.y + 1, newposition.z);
                    if (CheckWallBoxNext(boxes, boxes[i], nextToBox))
                    {
                        return true;
                    }
                }
                else if (direction == "down")
                {
                    nextToBox = new Vector3(newposition.x, newposition.y - 1, newposition.z);
                    if (CheckWallBoxNext(boxes, boxes[i], nextToBox))
                    {
                        return true;
                    }
                }

            }
        }
        return false;
    }

    private bool CheckWallBoxNext(GameObject[] boxes, GameObject CurrentBox, Vector3 nextToBox)
    {
        if (!checkWall(nextToBox)) 
                {
                    GameObject[] box = GameObject.FindGameObjectsWithTag("brownBox");

                    for (int j = 0; j < boxes.Length; j++)
                    {
                        if (box[j].transform.position == nextToBox)
                        {
                            keyPressed = false;
                            return false;
                        }
                    }

                    CurrentBox.transform.position = nextToBox;
                    return true;
                }
                keyPressed = false;
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
