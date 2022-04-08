using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class box : MonoBehaviour
{
    public SpriteRenderer boxSprite;
    public Sprite BlueBox;
    public Sprite BrownBox;

    [SerializeField] Text Score;
    public static int score;

    bool Win = false;

    void Start()
    {
        boxSprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (score == 7 && !Win)
        {  
            Score.text = "You Win!!";
            Win = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "blueDot")
        {
            boxSprite.sprite = BlueBox;
            score++;
            Score.text = ("Score: ") + score;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "blueDot")
        {
            boxSprite.sprite = BrownBox;
            score--;
            Score.text = ("Score: ") + score;
            Win = false;
        }
    }
}

/* 
       Rigidbody2D boxrigidbody; 
       boxrigidbody = GetComponent<Rigidbody2D>();
       if (collision.gameObject.tag == "brownBox")
        {
            boxrigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else if (collision.gameObject.tag == "player")
        {
            boxrigidbody.constraints = RigidbodyConstraints2D.None;
            boxrigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
*/
