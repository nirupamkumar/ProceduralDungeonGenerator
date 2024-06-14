using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button BTN_Enter;
    [SerializeField] private Button BTN_Exit;

    private void Awake()
    {
        BTN_Enter.onClick.AddListener(EnterDungeon);
        BTN_Exit.onClick.AddListener(ExitDungeon);
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
