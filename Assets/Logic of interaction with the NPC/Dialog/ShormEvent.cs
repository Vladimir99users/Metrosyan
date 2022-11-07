using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShormEvent : MonoBehaviour
{
    [SerializeField] private GameObject _screen;
    [SerializeField] private AudioSource _mainAudio;
    public void Begin()
    {
        StartCoroutine(Script());
    }

    private IEnumerator Script()
    {
        _mainAudio.Stop();
        GetComponent<AudioSource>().Play();
        _screen.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);
    }
}