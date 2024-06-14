using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class ExitDoorway : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = Vector2.one * 0.1f;
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }  
    }
}
