using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayer : MonoBehaviour
{
    public Canvas pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.GetComponent<PauseScreen>().player = GetComponent<PlayerBehaviour>();
            float timeScale = Time.timeScale;
            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None;

            pauseMenu.gameObject.SetActive(true);
            pauseMenu.GetComponent<PauseScreen>().timeScale = timeScale;
        }
    }
}
