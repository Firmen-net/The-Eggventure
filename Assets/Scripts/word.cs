using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word : MonoBehaviour
{
    public CanvasGroup panel1;
    public CanvasGroup panel2;
    public CanvasGroup panel3;
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
        if (timeElapsed > timedelay + 3)
        {
            panel1.alpha -= 0.1f;
            panel2.alpha += Time.deltaTime;
        }
        if (timeElapsed > timedelay + 5)
        {
            panel2.alpha -= 0.1f;
            panel3.alpha += Time.deltaTime;
        }
        if (timeElapsed > timedelay + 9)
        {
            panel3.alpha -= 0.1f;
        }
    }
}