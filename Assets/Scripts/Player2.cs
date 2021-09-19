using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //set speed
    public float speed = 8;
    Rigidbody2D rb2D;

    //turns player and animates
    public SpriteRenderer mySpriteRenderer;
    public Sprite[] Side = new Sprite[2];
    public Sprite[] spriteUp = new Sprite[2];
    public Sprite[] spriteDown = new Sprite[2];
    private int frame = 0;
    private int frameIndex = 0;

    public GameObject Bomb;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float movementHorizontal = 0;
        float movementVertical = 0;
        if (Input.GetKey(KeyCode.W))
        {
            movementVertical = speed;
            mySpriteRenderer.sprite = spriteUp[2];
            //player animation
            frame++;

                Sprite spriteWalk = spriteUp[frameIndex];
                mySpriteRenderer.sprite = spriteWalk;
                frameIndex++;
                if (frameIndex == spriteUp.Length)
                {
                    frameIndex = 0;
                }

        }

        if (Input.GetKey(KeyCode.S))
        {
            movementVertical = -speed;
            mySpriteRenderer.sprite = spriteDown[2];
            frame++;
            Sprite spriteWalk = spriteDown[frameIndex];
            mySpriteRenderer.sprite = spriteWalk;
            frameIndex++;
            if (frameIndex == spriteDown.Length)
            {
                frameIndex = 0;
            }
        }


        if (Input.GetKey(KeyCode.D))
        {
            movementHorizontal = speed;
            mySpriteRenderer.sprite = Side[2];
            mySpriteRenderer.flipX = false;
                frame++;
                Sprite spriteWalk = Side[frameIndex];
                mySpriteRenderer.sprite = spriteWalk;
                frameIndex++;
                if (frameIndex == Side.Length)
                {
                    frameIndex = 0;
                }

        }

        if (Input.GetKey(KeyCode.A))
        {
            movementHorizontal = -speed;
            mySpriteRenderer.flipX = true;

            frame++;
                Sprite spriteWalk = Side[frameIndex];
                mySpriteRenderer.sprite = spriteWalk;
                frameIndex++;
                if (frameIndex == Side.Length)
                {
                    frameIndex = 0;
                }

            }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlaceBomb();
        }

        rb2D.velocity = new Vector2(movementHorizontal, movementVertical);
    }

    void PlaceBomb()
    {
        Vector3 pos = transform.position;
        Instantiate(Bomb, pos, Quaternion.identity);

    }


}
