using UnityEngine;
using System.Collections;

public class paddleColorScript : MonoBehaviour {

    SpriteRenderer s1;
	// Use this for initialization
	void Start () {
        s1 = GetComponent<SpriteRenderer>();
        setColor();//
	}

    void setColor()
    {
        float r = Random.Range(0.1f, 1.0f);
        float g = Random.Range(0.1f, 1.0f);
        float b = Random.Range(0.1f, 1.0f);

        s1.color = new Vector4(r, g, b, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
