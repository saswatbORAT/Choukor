using UnityEngine;
using System.Collections;

public class menuPaddleScript : MonoBehaviour {
	// Use this for initialization
	void Start () 
    {
	}
	// Update is called once per frame
	void Update () {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.nearClipPlane));
        transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);
	}
}
