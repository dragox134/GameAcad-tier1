using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayer : MonoBehaviour
{
    public Canvas pauseMenu;
    public float timeScale;

    void Awake()
    {
        pauseMenu.GetComponent<PauseScreen>().player = GetComponent<PlayerBehaviour>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.GetComponent<PauseScreen>().PauseMenuOn == false)
        {
            timeScale = Time.timeScale;
            Time.timeScale = 0;
            pauseMenu.GetComponent<PauseScreen>().timeScale = this.timeScale;

            Cursor.lockState = CursorLockMode.None;

            pauseMenu.gameObject.SetActive(true);

            pauseMenu.GetComponent<PauseScreen>().PauseMenuOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.GetComponent<PauseScreen>().PauseMenuOn == true)
        {
            Time.timeScale = timeScale;

            Cursor.lockState = CursorLockMode.Locked;

            pauseMenu.GetComponent<PauseScreen>().PauseMenuOn = false;
            pauseMenu.gameObject.SetActive(false);
        }
    }
}
