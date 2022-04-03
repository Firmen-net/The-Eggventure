using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //private Rigidbody2D rb;
    private bool moveable = false;

    public float speed = 5;

    [Header("Pilih Tipe Gerak")]
    public bool vertical;

    public bool horizontal;

    [Header("Batas Gerak Vertical")]
    public float batasAtas = 0;

    public float batasBawah = 0;

    [Header("Batas Gerak Horizontal")]
    public float batasKiri = 0;

    public float batasKanan = 0;
    public GameObject platOn;

    // Start is called before the first frame update
    private void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        int layer_maskb = LayerMask.GetMask("Background");
        int layer_maskp = LayerMask.GetMask("Platform");

        PlatforMove();

        //OBJEK DIKLIK MOUSE
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider.gameObject != this.gameObject)
            {
                Debug.Log(hit.collider.name);
                moveable = false;
                platOn.SetActive(false);
            }
            if (hit.collider.gameObject == this.gameObject)
            {
                moveable = true;
                Debug.Log(this.gameObject.name + "Moveable");
                platOn.SetActive(true);
            }
        }
    }

    private void PlatforMove()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //GERAK VERTIKAL
        if (vertical && !horizontal)
        {
            if (moveable)
            {
                // rb.velocity = new Vector2(0, v) * speed;
                transform.Translate(0, v * Time.deltaTime * speed, 0);
            }

            if (!moveable)
            {
                //rb.velocity = new Vector2(0, 0);
                transform.Translate(0, 0, 0);
            }

            if (transform.position.y > batasAtas)
            {
                transform.position = new Vector2(transform.position.x, batasAtas);
            }
            if (transform.position.y < batasBawah)
            {
                transform.position = new Vector2(transform.position.x, batasBawah);
            }
        }

        //GERAK HORIZONTAL
        else if (horizontal && !vertical)
        {
            if (moveable)
            {
                transform.Translate(h * Time.deltaTime * speed, 0, 0);
                // rb.velocity = new Vector2(h, 0) * speed;
            }

            if (!moveable)
            {
                //rb.velocity = new Vector2(0, 0);
                transform.Translate(0, 0, 0);
            }

            if (transform.position.x > batasKanan)
            {
                transform.position = new Vector2(batasKanan, transform.position.y);
            }
            if (transform.position.x < batasKiri)
            {
                transform.position = new Vector2(batasKiri, transform.position.y);
            }
        }
    }
}