using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public static SceneLoader Instance;
    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Image _progressBar;
    [SerializeField]float _target;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator LoadSceneCourutine(string sceneName)
    {
        _target = 0;
        _progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);

         while (!scene.isDone)
         {
            if (scene.progress >= 0.9f)
            {
                scene.allowSceneActivation = true;
            }
            _target = scene.progress;

            yield return null;
         }
    }

    void Update()
    {
        _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target, 3 * Time.deltaTime);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCourutine(sceneName));
    }
}
