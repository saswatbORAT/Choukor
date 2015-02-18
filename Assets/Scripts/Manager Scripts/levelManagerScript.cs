using UnityEngine;
using System.Collections;

public class levelManagerScript : MonoBehaviour {
    
    public GameObject[] level;
    public GameObject currentLevel;

    public GameObject Manager;
    public managerScript _managerScript;

    public int brickCount;
    public int levelCount;
    // Use this for initialization
	void Start () {
        _managerScript = Manager.GetComponent<managerScript>();
        levelCount = PlayerPrefs.GetInt("levelCount");
	}

    public void loadLevel()
    {
        currentLevel = Instantiate(level[levelCount], level[levelCount].transform.position, Quaternion.identity) as GameObject;
        currentLevel.name = "Level" + (levelCount + 1).ToString();
        brickCount = currentLevel.transform.GetComponentsInChildren<brickScript>().Length;
    }

	// Update is called once per frame//
	void Update () {
	
	}
}
