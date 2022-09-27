using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public static GameLoader Instance;

    public bool[] loadSlots = new bool[3];

    private void Start()
    {
        TryLoadData();
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);


        }
        else
        {
            Instance = this;
        }
    }

    void TryLoadData()
    {
        for (int i = 0;i < 3; i++ )
        { 
            string path = Application.persistentDataPath + "/player" + i + ".fun";
            Debug.Log(path);
            if (File.Exists(path))
            {
                loadSlots[i] = true;
            }
        }
    }
}
