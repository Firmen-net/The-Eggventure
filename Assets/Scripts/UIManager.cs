using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject PauseUI;
    public GameObject credit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            credit.SetActive(false);
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void ContinueBtn()
    {
        audioSource.Play();
        Debug.Log("Continue");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitBtn()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }

    public void StartBtn()
    {
        audioSource.Play();
        SceneManager.LoadScene(1);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

    public void MuteButton()
    {
        audioSource.Play();
        AudioListener.volume = 1 - AudioListener.volume;
    }

    public void pauseBtn()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void unpause()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void credits()
    {
        credit.SetActive(true);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }
}