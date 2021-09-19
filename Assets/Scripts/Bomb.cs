using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public GameObject Explosion;
    public int Magnitude = 2;
    public GameObject box;

    //Bomb animation
    public Sprite[] frames;
    public float animationFPS;
    SpriteRenderer SR;
    float FrameTimer;
    int CurrentFrame;

    // Start is called before the first frame update
    void Start()
    {
        //bomb animation
        SR = GetComponent<SpriteRenderer>();
        FrameTimer = 0;
        CurrentFrame = 0;
        StartCoroutine(waitToDestroy());

    }

    // Update is called once per frame
    void Update()
    {
        FrameTimer -= Time.deltaTime;
        if (FrameTimer <= 0)
        {
            SR.sprite = frames[CurrentFrame];
            FrameTimer = 1 / animationFPS;
            CurrentFrame++;
        }

    }


    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        PlaceExplosion();
    }

    void PlaceExplosion()
    {
        Vector3 pos = transform.position;
        Instantiate(Explosion, pos, Quaternion.identity);

        Vector3 originUp = transform.position;
        Vector3 directionUp = Vector3.up;
        RaycastHit2D hit = Physics2D.Raycast(originUp, directionUp, Magnitude);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (hit.collider.CompareTag("Box"))
            {
                Destroy(hit.collider.gameObject);
            }
        }

        Vector3 originDown = transform.position;
        Vector3 directionDown = Vector3.down;
        RaycastHit2D hit2 = Physics2D.Raycast(originDown, directionDown, Magnitude);
        if (hit2.collider != null)
        {
            if (hit2.collider.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (hit2.collider.CompareTag("Box"))
            {
                Destroy(hit2.collider.gameObject);
            }
        }

        Vector3 originLeft = transform.position;
        Vector3 directionLeft = Vector3.left;
        RaycastHit2D hit3 = Physics2D.Raycast(originLeft, directionLeft, Magnitude);
        if (hit3.collider != null)
        {
            if (hit3.collider.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (hit3.collider.CompareTag("Box"))
            {
                Destroy(hit3.collider.gameObject);
            }

        }

        Vector3 originRight = transform.position;
        Vector3 directionRight = Vector3.right;
        RaycastHit2D hit4 = Physics2D.Raycast(originRight, directionRight, Magnitude);
        if (hit4.collider != null)
        {
            if (hit4.collider.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (hit4.collider.CompareTag("Box"))
            {
                Destroy(hit4.collider.gameObject);
            }

        }
    }
}




  

