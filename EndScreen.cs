using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Written by Zane
public class EndScreen : MonoBehaviour
{
    [SerializeField] public bool win;
    [SerializeField] private TextMeshProUGUI loseText;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        if (win)
        {
            AudioManager.instance.Play("Win");
        }
        else
        {
            loseText.text = GhostTask.loseMessageText;
            AudioManager.instance.PlayOneShot("Explostion");
            AudioManager.instance.Play("Lose");
        }
    }

    // quits to the main menu
    public void QuitToMenu()
    {
        GameManager.QuitToMenu();
    }

    // restarts the game
    public void Restart()
    {
        if (win)
        {
            GameManager.NewGame();
        }
        else
        {
            GameManager.RestartLevel();
        }
    }
}
