using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class EntranceDoorScript : MonoBehaviour
{
    public int minSize;
    public int maxSize;
    private bool isPlayerNear = false;

    private void Reset()
    {
        GetComponent<Rigidbody>().isKinematic = true;

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            int dungeonSize = Random.Range(minSize, maxSize);
            PlayerPrefs.SetInt("DungeonSize", dungeonSize);
            PlayerPrefs.Save();
            SceneManager.LoadScene("DungeonScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            UIManager.ShowInteractPrompt(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            UIManager.ShowInteractPrompt(false);
        }
    }
}
