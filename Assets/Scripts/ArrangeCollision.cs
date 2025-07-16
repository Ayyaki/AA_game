using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangeCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("arrowHead") && collision.gameObject.CompareTag("arrowHead"))
        {

        }
        else if (gameObject.CompareTag("arrowTail") && collision.gameObject.CompareTag("centerCircle"))
        {

        }
    }
}
