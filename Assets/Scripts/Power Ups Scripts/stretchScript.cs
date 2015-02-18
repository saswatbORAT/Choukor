using UnityEngine;
using System.Collections;

public class stretchScript : MonoBehaviour {
    public GameObject ball;
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D pCollider2D)
    {
        if (pCollider2D.gameObject.name == "Paddle")
        {
            Instantiate(ball, ball.transform.position, Quaternion.identity);
            pCollider2D.transform.localScale += new Vector3(0.5f, 0.0f, 0.0f);
            Destroy(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(0.0f, -0.02f, 0.0f);////
	
	}
}
