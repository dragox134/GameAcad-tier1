using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public float timeScale;
    public PlayerBehaviour player;

    public void Resume()
    {
        Time.timeScale = timeScale;

        Cursor.lockState = CursorLockMode.Locked;

        gameObject.SetActive(false);
    }

    public void Settings()
    {

    }

    public void Menu(string sceneName)
    {
        player.SavePlayer();

        SceneLoader.Instance.LoadScene(sceneName);
    }
}
