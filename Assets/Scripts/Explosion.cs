using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Sprite[] frames;
    public float animationFPS;
    SpriteRenderer SR;
    float FrameTimer;
    int CurrentFrame;


    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        FrameTimer = 0;
        CurrentFrame = 0;
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
        StartCoroutine(waitToDestroy());

    }


    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
