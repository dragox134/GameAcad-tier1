using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Canvas play;
    public Canvas options;
    public Canvas MainMenu;

    public GameObject[] saveButtons;
    public GameObject[] loadButtons;
    int i = 0;

    PlayerBehaviour player;
    public GameObject playerGameObject;

    private void Start()
    {
        player = playerGameObject.GetComponent<PlayerBehaviour>();
        Debug.Log(player.maxHealth);
    }

    public void PlayeScreen()
    {
        play.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);

        while (i <= 2)
        {
            Debug.Log("i je" + i);
            if (GameLoader.Instance.loadSlots[i] == true)
            {
                saveButtons[i].SetActive(false);
                loadButtons[i].SetActive(true);
            }
            else
            {
                saveButtons[i].SetActive(true);
                loadButtons[i].SetActive(false);
            }
            i++;
        }
    }

    public void OptionsScreen()
    {
        options.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        MainMenu.gameObject.SetActive(true);
        GetComponentInParent<Canvas>().gameObject.SetActive(false);
    }
    
    public void SaveButton0(string sceneName)
    {
        Debug.Log("haha");
        GameLoader.Instance.loadSlots[0] = true;
        player.saveSlot = 0;
        
        saveButtons[0].SetActive(false);
        loadButtons[0].SetActive(true);
        player.SavePlayer();
        SceneLoader.Instance.LoadScene(sceneName);
    }
    public void SaveButton1(string sceneName)
    {
        GameLoader.Instance.loadSlots[1] = true;
        player.saveSlot = 1;

        saveButtons[1].SetActive(false);
        loadButtons[1].SetActive(true);
        player.SavePlayer();
        SceneLoader.Instance.LoadScene(sceneName);
    }
    public void SaveButton2(string sceneName)
    {
        GameLoader.Instance.loadSlots[2] = true;
        player.saveSlot = 2;

        saveButtons[2].SetActive(false);
        loadButtons[2].SetActive(true);
        player.SavePlayer();
        SceneLoader.Instance.LoadScene(sceneName);
    }


    public void LoadButton0(string sceneName)
    {
        player.loadSlot = 0;
        SceneLoader.Instance.LoadScene(sceneName);
    }
    public void LoadButton1(string sceneName)
    {
        player.loadSlot = 1;
        SceneLoader.Instance.LoadScene(sceneName);
    }
    public void LoadButton2(string sceneName)
    {
        player.loadSlot = 2;
        SceneLoader.Instance.LoadScene(sceneName);
    }
}
