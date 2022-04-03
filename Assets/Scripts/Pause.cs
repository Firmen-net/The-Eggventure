using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseUI;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void pauseBtn()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void unpauseBtn()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}