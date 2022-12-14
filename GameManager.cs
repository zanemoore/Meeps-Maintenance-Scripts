using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Written by Zane
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<string> levels = new List<string>();
    [SerializeField] private string SceneName;

    private int level = 1;
    public static int lastScene;

    private static GameManager instance;

    enum GAMESTATE
    {
        TITLESCREEN,
        PLAYING,
        PAUSED,
        WIN,
        LOSE
    }

    ///private static GAMESTATE state;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public static void TitleScreen()
    {
        ///state = GAMESTATE.TITLESCREEN;
    }

    public static void NewGame()
    {
        ///state = GAMESTATE.PLAYING;
        instance.level = 1;
        SceneManager.LoadScene(instance.levels[0]);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }

    public static void NextLevel()
    {
        ///state = GAMESTATE.PLAYING;
        AudioManager.instance.Stop("MainTheme");
        SceneManager.LoadScene(instance.levels[instance.level++]);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static void RestartLevel()
    {
        if (lastScene == 1)
        {
            SceneManager.LoadScene(1);
        }
        else if (lastScene == 2)
        {
            SceneManager.LoadScene(2);
        }
        else if (lastScene == 3)
        {
            SceneManager.LoadScene(3);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }

    public static void PauseRestart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }

    public static void PauseGame()
    {
        ///state = GAMESTATE.PAUSED;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public static void ResumeGame()
    {
        ///state = GAMESTATE.PLAYING;
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static void QuitToMenu()
    {
        ///state = GAMESTATE.TITLESCREEN;
        AudioManager.instance.Stop("MainTheme");
        instance.level = 1;
        SceneManager.LoadScene(0);
    }

    public static void WinScreen()
    {
        ///state = GAMESTATE.WIN;
        AudioManager.instance.Stop("MainTheme");
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Win");
    }

    public static void LoseScreen()
    {
        ///state = GAMESTATE.LOSE;
        AudioManager.instance.Stop("MainTheme");
        Cursor.lockState = CursorLockMode.None;
        lastScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Lose");
    }
}
