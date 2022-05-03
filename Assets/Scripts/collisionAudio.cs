using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class collisionAudio : MonoBehaviour
{
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.collider.name == "Ball")
        {
            FindObjectOfType<AudioManager>().Stop("Introduccion");
            FindObjectOfType<AudioManager>().Play("Abajo");
            
        }
    }
}
