using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Egg : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D bc;
    [SerializeField] private LayerMask platformLayerMask;
    /*private bool moveRight = true;
    private bool moveLeft = false;*/
    private bool notdie = true;

    // private bool gameover = false;
    public float moveSpeed = 5;

    public GameObject finishedui;

    public GameObject die;

    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    private void Start()
    {
        finishedui.SetActive(false);

        die.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }

    private void FixedUpdate()
    {
        moveright();
        /*if (moveRight && !moveLeft)
        {
            moveright();
        }*/
        /*else if (!moveRight && moveLeft)
        {
            moveleft();
        }
*/
        if (rb.transform.position.y < -6)
        {
            Gameover();
        }
    }

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    //Gerak Ke Kanan
    private void moveright()
    {
        if (isGrounded() && notdie == true)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
    }

    //Gerak Ke Kiri
    /*private void moveleft()
    {
        if (isGrounded())
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {/*
        //Cek Saat Player Menyentuh Dinding Kanan
        if (collision.gameObject.CompareTag("RightWall"))
        {
            Debug.Log("Putar Kiri");
            moveRight = false;
            moveLeft = true;
        }
        //Cek Saat Player Menyentuh Dinding Kiri
        else if (collision.gameObject.CompareTag("LeftWall"))
        {
            Debug.Log("Putar Kanan");
            moveRight = true;
            moveLeft = false;
        }*/

        if (collision.gameObject.CompareTag("FinishLine"))
        {
            playClip();
            rb.simulated = false;
            finishedui.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Gameover();
        }
    }

    private void Gameover()
    {
        die.GetComponent<Die>().enabled = true;
        notdie = false;
        rb.simulated = false;
        die.SetActive(true);
    }

    //CekApakahPlayerMenyentuhPlatform
    private bool isGrounded()
    {
        float extraHeigh = -1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, Vector2.down, bc.bounds.extents.y + extraHeigh, platformLayerMask);
        return raycastHit.collider != null;
    }
}