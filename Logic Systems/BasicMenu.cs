using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasicMenu : MonoBehaviour
{
    //This script contains public functions that are called via UI button press.

    //Load scene by name.
    public void GoToScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    //Load next scene.
    public void GoToNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //Reset all PlayerPrefs.
    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    //Reset a specific PlayerPref.
    public void DeletePlayerPrefKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    //Show a hidden menu object.
    public void ShowObject(GameObject item)
    {
        item.SetActive(true);
    }

    //Hide a menu object.
    public void HideObject(GameObject item)
    {
        item.SetActive(false);
    }

    //Set the time scale to a value (0 is stopped, 1 is normal, etc.).
    public void SetTimeScale(float t)
    {
        Time.timeScale = t;
    }

    //Quit a standalone game.
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetMusicVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
    }
    public void SetUIVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("UIVolume", slider.value);
    }
    public void SetSFXVolume(Slider slider)
    {
        PlayerPrefs.SetFloat("SFXVolume", slider.value);
    }

    public void PlayUIClip(AudioClip clip)
    {
        GameObject a;
        AudioSource aSource;

        a = GameObject.FindGameObjectWithTag("UI");
        if (a)
        {
            aSource = a.GetComponent<AudioSource>();
            aSource.PlayOneShot(clip);
        }
    }

    IEnumerator LoadLevel(string sceneName)
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator LoadLevel(int buildIndex)
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(buildIndex);
    }
}
