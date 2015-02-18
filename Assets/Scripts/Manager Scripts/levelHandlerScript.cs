using UnityEngine;
using System.Collections;

public class levelHandlerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void level(int levelCount)
    {
        PlayerPrefs.SetInt("levelCount", levelCount);
        Application.LoadLevel("Game");
    }
	// Update is called once per frame
	void Update () {
	
	}
}
