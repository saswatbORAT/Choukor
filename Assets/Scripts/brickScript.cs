using UnityEngine;
using System.Collections;

public class brickScript : MonoBehaviour {
    
    SpriteRenderer s1;
    public Sprite brickSprite;
    public Sprite metalBrickSprite;
    public Sprite metalBrick_Crack;

    bool colliding;
    public bool isMetalBrick;
	// Use this for initialization
	
    void Start ()
    {
        colliding = false;
        s1 = GetComponent<SpriteRenderer>();

        setColor();
	}

    void setColor()//sets brick color
    { 
        float r = Random.Range(0.1f, 1.0f);
        float g = Random.Range(0.1f, 1.0f);//
        float b = Random.Range(0.1f, 1.0f);

        s1.color = new Vector4(r,g,b,1.0f);

        if (isMetalBrick)
        {
            s1.sprite = metalBrickSprite;
        }
    }
    
    void OnCollisionEnter2D(Collision2D pCollision2D)
    {
        if (pCollision2D.gameObject.tag == "Ball" && !colliding)//checks if the brick is colliding with the ball
        {
            if (isMetalBrick)
            {
                isMetalBrick = false;
                s1.sprite = brickSprite;
                return; 
            }
            else
            {
                colliding = true;
                Destroy(gameObject, Time.deltaTime);
            }//
            /*destroy the brick in the next frame//
            (so that the ball can properly collide)*/
        }
    }

    void OnCollisionExit()
    {
        colliding = false;
    }

}
