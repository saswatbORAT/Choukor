using UnityEngine;
using System.Collections;

public class menuBallScript : MonoBehaviour {
    ballScript _ballScript;

    public Transform paddle;
	// Use this for initialization
	void Start () {
            _ballScript = GetComponent<ballScript>();
	}
   
    void OnCollisionEnter2D(Collision2D pCollision2D)
    { 
        if (pCollision2D.gameObject.name == "Play Collider")
        {
            Application.LoadLevel("Levels");
        }
        else if (pCollision2D.gameObject.name == "Controls Collider")
        {
            Application.LoadLevel("Controls");
        }
        else if (pCollision2D.gameObject.name == "High Scores Collider")
        {
            print("high scores");
        }
        else if (pCollision2D.gameObject.name == "Exit Collider")
        {
            Application.Quit();
        }
        else 
        {
            if (pCollision2D.gameObject.transform != paddle)
            {
                transform.position = paddle.position + new Vector3(0, 0.1f, 0);//
                transform.parent = paddle;
                _ballScript.release = false;
                transform.eulerAngles = Vector3.zero;
                transform.localScale = new Vector3(0.125f, 0.5f,1);
            }
        }
    }


	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _ballScript.gameObject.transform.parent = null;
            _ballScript.release = true;
        }
	
	}
}
