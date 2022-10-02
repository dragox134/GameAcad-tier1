using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public float timeScale;
    public PlayerBehaviour player;
    public Canvas SettingsCanvas;
    public bool PauseMenuOn;

    public void Resume()
    {
        Time.timeScale = timeScale;

        Cursor.lockState = CursorLockMode.Locked;

        PauseMenuOn = false;
        gameObject.SetActive(false);
    }

    public void Settings()
    {
        SettingsCanvas.gameObject.SetActive(true);
    }

    public void Menu(string sceneName)
    {
        player.SavePlayer();

        Time.timeScale = timeScale;

        SceneLoader.Instance.LoadScene(sceneName);
    }
}
