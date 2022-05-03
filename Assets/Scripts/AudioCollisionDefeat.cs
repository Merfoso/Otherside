using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioCollisionDefeat : MonoBehaviour
{
    public Player ball;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ball")
        {
            ball.triesCount++;
            SceneManager.LoadScene("Level 1");
        }
       
    }
}
