using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerCon : MonoBehaviour
{
    public int speed = 0;
    private float score = 0;
    Rigidbody RB;
    public Text Score;
    private float level;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();

        Scene currentscene = SceneManager.GetActiveScene();
        string scenename = currentscene.name;

        if (scenename == "Game")
        {
            level = 1;
        }
        else if (scenename == "Level 2")
        {
            level = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + score;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RB.velocity = transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RB.velocity = -transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RB.velocity = transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            RB.velocity = -transform.right * speed * Time.deltaTime;
        }
        else
        {
            RB.velocity = new Vector3(0, 0, 0);
        }

        if (score == 4)
        {
            if (level == 1)
            {
                SceneManager.LoadScene("Level 2");
            }

            else if (level == 2)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
