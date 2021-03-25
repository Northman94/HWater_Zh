using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    //Reference to LoadingUI
    [SerializeField]
    private GameObject loadingUI;
    [SerializeField]
    private Slider loadingSlider;

    [SerializeField]
    private GameObject mainMenuUI;



    private void Start()
    {
        //Initialization NO!
        //mainMenuUI = GameObject.Find("MainCanvas");
        //loadingUI = GameObject.Find("LoadingUI");

        mainMenuUI.SetActive(true);
        loadingUI.SetActive(false);
    }

    public void PlayGameButton()
    {
        StartCoroutine(LoadAsynchronously());

        FindObjectOfType<AudioManagerScript>().StopAudio("MainTheme");
        FindObjectOfType<AudioManagerScript>().PlaySounds();
        FindObjectOfType<AudioManagerScript>().PlayAudio("SecondSceneTheme");
    }

    

    //Loading progress bar
    IEnumerator LoadAsynchronously()
    {
        AsyncOperation loadingProgress = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        loadingUI.SetActive(true);
        mainMenuUI.SetActive(false);

        while (!loadingProgress.isDone)
        {
            float progress = Mathf.Clamp01(loadingProgress.progress / 0.9f); //Asset loading 0-0.9f fix to 0-1

            loadingSlider.value = progress;

            yield return null; //Wait untill next FRAME
        }
    }


    /*
    public void QuitGameButton()
    {
        Application.Quit();
    }
    */
}
