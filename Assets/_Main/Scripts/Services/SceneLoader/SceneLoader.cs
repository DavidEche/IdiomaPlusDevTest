using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingBar;
    public void LoadLevel(string nameScene){
        StartCoroutine(LoadAsynchronouly(nameScene));
    }

    private IEnumerator LoadAsynchronouly(string nameScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/.9f);
            loadingBar.value = progress;
            yield return null;
        }
        loadingScreen.SetActive(false);
    }
}
