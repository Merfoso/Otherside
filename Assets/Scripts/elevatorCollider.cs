using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorCollider : MonoBehaviour
{
    public bool choco = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            choco = true;
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
