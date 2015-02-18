using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonScript : MonoBehaviour {
    Image image;
    // Use this for initialization
	void Start () {
	    image = GetComponent<Image>();
        
        float r = Random.Range(0.1f,1.0f);
        float g = Random.Range(0.1f,1.0f);
        float b = Random.Range(0.1f,1.0f);

        image.color = new Vector4(r, g, b, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
