using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingFirstSceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject firstSceneLoadingUI;
    [SerializeField]
    private Slider firstSceneLoadingSlider;
    [SerializeField]
    private GameObject secondSceneMenuUI;


    private void Start()
    {
        secondSceneMenuUI.SetActive(true);
        firstSceneLoadingUI.SetActive(false);
    }

    public void MenuButton()
    {
        StartCoroutine(LoadAsynchronously());

        FindObjectOfType<AudioManagerScript>().StopAudio("SecondSceneTheme");
        FindObjectOfType<AudioManagerScript>().BackToMenu();
        FindObjectOfType<AudioManagerScript>().PlayAudio("MainTheme");
    }
    

    //Loading progress bar
    IEnumerator LoadAsynchronously()
    {
        AsyncOperation loadingProgress = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);

        firstSceneLoadingUI.SetActive(true);
        secondSceneMenuUI.SetActive(false);

        while (!loadingProgress.isDone)
        {
            float progress = Mathf.Clamp01(loadingProgress.progress / 0.9f); //Asset loading from 0 to 0.9f fixed to 0-1

            firstSceneLoadingSlider.value = progress;

            yield return null; //Wait untill next FRAME
        }
    }
}
