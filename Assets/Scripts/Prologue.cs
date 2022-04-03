using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
    public CanvasGroup panel1;
    public CanvasGroup panel2;
    public CanvasGroup panel3;
    public CanvasGroup panel4;
    public float timedelay = 1f;
    private float timeElapsed;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > timedelay)
        {
            panel1.alpha += Time.deltaTime;
        }
        if (timeElapsed > timedelay + 2)
        {
            panel2.alpha += Time.deltaTime;
        }
        if (timeElapsed > timedelay + 4)
        {
            panel3.alpha += Time.deltaTime;
        }
        if (timeElapsed > timedelay + 8)
        {
            panel4.alpha += Time.deltaTime;
        }
    }
}