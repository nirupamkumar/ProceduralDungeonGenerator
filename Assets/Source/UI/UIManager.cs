using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject interactPrompt;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void ShowInteractPrompt(bool show)
    {
        instance.interactPrompt.SetActive(show);
    }

    private void EnterDungeon()
    {
        SceneManager.LoadScene(1);
    }

    private void ExitDungeon()
    {
        Application.Quit();
    }
}
