using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "DoorBreak")
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "DoorBreak")
        {
            gameObject.SetActive(false);
        }
    }
}
