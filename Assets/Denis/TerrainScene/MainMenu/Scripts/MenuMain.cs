using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuMain : MonoBehaviour
{
    public Slider _progressSlider;

    public void LoadLevel(int SceneIndex)
    {
        StartCoroutine(LoadAsynshronousle(SceneIndex));
    }

    IEnumerator LoadAsynshronousle (int Index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(Index);
    
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/.9f);
            _progressSlider.value = progress;
            yield return null;
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        Debug.Break();
        #endif
        Application.Quit();
    }
}
