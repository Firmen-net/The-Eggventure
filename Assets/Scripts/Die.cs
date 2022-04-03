using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{
    public float timedelay = 3f;
    private float timeElapsed;

    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    private void Start()
    {
        //playClip();
        Vector2 pos = GameObject.Find("Egg").transform.position;
        transform.position = new Vector2(pos.x, pos.y);
    }

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(0, 3 * Time.deltaTime, 0);
        timeElapsed += Time.deltaTime;
        if (timeElapsed > timedelay)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
    }
}