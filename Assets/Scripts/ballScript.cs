using UnityEngine;
using System.Collections;

public class ballScript : MonoBehaviour {

    public GameObject Manager;
    managerScript _managerScript;//needed to reset the ball position
    
    public bool release;
    public Vector2 speed;//ball speed

    SpriteRenderer s1;

    public float speedDifference;

    bool colliding;

    Vector4 color;

    public int multiplier;

    // Use this for initialization//
	void Start () {

        multiplier = 1;

        speedDifference = 15;
        speed = Vector2.zero;

        release = false;

        color = Vector4.zero;
        s1 = GetComponent<SpriteRenderer>();

        _managerScript = Manager.GetComponent<managerScript>();
	}

    void setColor(float alpha)
    {
        color.x = Random.Range(0.1f, 1.0f);
        color.y = Random.Range(0.1f, 1.0f);
        color.z = Random.Range(0.1f, 1.0f);
        color.w = alpha;

        s1.color = color;
    }

    void OnCollisionEnter2D(Collision2D pCollision2D)
    {
        if (!colliding)//to collide the gameobjcts only once
        {
            setColor(1);
            if (pCollision2D.gameObject.name == "Brick")
            {
                _managerScript.checkScore(multiplier);//increases score
                if (multiplier < 10)
                {
                    multiplier++;//increases multiplier
                }
            }
            /*calculates the angle between the ball and the colliding gameObject*/
            speed.x = Mathf.Cos(Angle(pCollision2D.gameObject.transform.position, transform.position) * Mathf.Deg2Rad);
            speed.y = Mathf.Sin(Angle(pCollision2D.gameObject.transform.position, transform.position) * Mathf.Deg2Rad);
            
            if (_managerScript._textManagerScript != null)//changes text of multiplier
            {
                updateMultiplierText();
            }
            
            colliding = true;
        }
    }

    void updateMultiplierText()
    {
        _managerScript._textManagerScript.MultiplierText.text = "Multiplier : " + multiplier.ToString() + "X";
    }

    void OnCollisionExit2D()
    {
        colliding = false;
    }

    void OnTriggerEnter2D(Collider2D pCollider2D)
    {
        if (pCollider2D.gameObject.tag == "Pocket")
        {
            release = false;
            _managerScript.reset();
        }
        if (pCollider2D.gameObject.tag == "LRCollider")
        {
            speed.x *= -1;
            multiplier = 1;
        }
        if (pCollider2D.gameObject.tag == "TBCollider")
        {
            speed.y *= -1;
            multiplier = 1;
        }
        if (pCollider2D.gameObject.tag == "Paddle")
        {
            speed.x = Mathf.Cos(Angle(pCollider2D.gameObject.transform.position, transform.position) * Mathf.Deg2Rad);
            speed.y = Mathf.Sin(Angle(pCollider2D.gameObject.transform.position, transform.position) * Mathf.Deg2Rad);
        }
        if (_managerScript._textManagerScript != null)//changes text of multiplier
        {
            updateMultiplierText();
        }
    }

    public float Angle(Vector3 paddleTransform,Vector3 ballTransform)//returns angle between the ball and the colliding gameObject
    {
        Vector2 delta;
        
        delta.x =  ballTransform.x - paddleTransform.x;
        delta.y =  ballTransform.y - paddleTransform.y;

        return Mathf.Atan2(delta.y,delta.x) * 180 / Mathf.PI;
    }

	void Update ()
    {
        if (release)
        {
            transform.eulerAngles += new Vector3(0, 0, 1);
            transform.position += new Vector3((speed.x / speedDifference)*(Time.deltaTime*60), (speed.y / speedDifference)*(Time.deltaTime*60), 0);
        }
    }
}
