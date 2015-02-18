using UnityEngine;
using System.Collections;

public class paddleScript : MonoBehaviour {
    public bool released;
    public Vector2 touchPos;
    bool touched;
	// Use this for initialization
	void Start () {
        touched = false;
        released = true;
	}

    float joyStickInput(float speed)
    {
        if (speed < 0)
        {
            speed = -1;
        }
        else if (speed > 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
        }
        return speed;
    }

	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            touched = true;
            touchPos = Input.touches[0].position;
        }
        else
        {
            touched = false;
        }
      
        if (released)
        {
            transform.eulerAngles += new Vector3(0, 0, joyStickInput(Input.GetAxis("Horizontal")));
        }
       

       if ((Input.GetKey(KeyCode.LeftArrow) || (touchPos.x < Screen.width*0.5f && touched)) && released)
       {
           transform.eulerAngles += new Vector3(0, 0, -60*Time.deltaTime);    
       }
       if ((Input.GetKey(KeyCode.RightArrow) || (touchPos.x > Screen.width*0.5f && touched)) && released)
       {
           transform.eulerAngles += new Vector3(0, 0, 60*Time.deltaTime);
       }
       if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
       {
           released = true;
       }
	
	}
}
