using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hi_Scores_Script : MonoBehaviour {
    string level;
    string score;

    public GameObject levelManager;
    levelManagerScript _levelManagerScript;

    int[] scores = {0,0,0};

    Text scoreText;
	// Use this for initialization
	void Start () {
        _levelManagerScript = levelManager.GetComponent<levelManagerScript>();
        scoreText = GetComponent<Text>();
        
        level = "Level" + _levelManagerScript.levelCount.ToString();
        for (int i = 0; i < scores.Length; i++)//
        {
            score = "Score" + i.ToString();
            scores[i] = PlayerPrefs.GetInt(level+score);
        }
        showScores();
	}

    void showScores()
    {
        scoreText.text = "1." + scores[0] + "\n" +
                         "2." + scores[1] + "\n" +
                         "3." + scores[2];
    }

	// Update is called once per frame
	void Update () {
	
	}
}
