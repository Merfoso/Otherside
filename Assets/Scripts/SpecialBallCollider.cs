using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBallCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ball")
        {
            gameObject.SetActive(false);
            FindObjectOfType<VoiceCommandsLvl2>().platformVerticalC.SetActive(true);
        }
    }
}
