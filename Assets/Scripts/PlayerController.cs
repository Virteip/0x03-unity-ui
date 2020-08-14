using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public int health = 5;
    public float speed = 200;
    public Rigidbody rb;
    private int score = 0;

    // Check health
    void Update()
    {
        if (health == 0)
        {
            Debug.Log ("Game Over!");
            SceneManager.LoadScene("Maze", LoadSceneMode.Single);
            score = 0;
            health = 5;
        }
    }    

    // Move with wasd
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(0, 0, -speed * Time.deltaTime);
    }


    // Trigger Actions When Tag Is Touched
    void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log ("Score: " + score);
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Trap")
        {
            health--;
            Debug.Log ("Health: " + health);
        }

        if (other.tag == "Goal")
        {
            Debug.Log ("You win!");
        }
    }
}
