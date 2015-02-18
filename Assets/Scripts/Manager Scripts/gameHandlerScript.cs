using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameHandlerScript : MonoBehaviour {

    int score;
    int levelCount;
    public GameObject scoreGameObject;
    public Text scoreText;

    int i;
    int temp;
    public int[] hi_scores = {0,0,0};

    string scoreVar;

    public GameObject nextLevel;

	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt("currentScore");
        levelCount = PlayerPrefs.GetInt("levelCount");

        scoreText = scoreGameObject.GetComponent<Text>();
        scoreText.text = score.ToString();////

        getValues();//
        setValues();

        if (levelCount == 2)
        { 
            nextLevel.GetComponent<Button>().interactable = false;
        }
	}

    void getValues()
    {
        for (i = 0; i < hi_scores.Length; i++)//reading data from file
        {
            scoreVar = "Level"+levelCount.ToString()+"Score"+i.ToString();
            hi_scores[i] = PlayerPrefs.GetInt(scoreVar);
        }
    }

    void setValues()
    {
        if (score > hi_scores[hi_scores.Length - 1])
        {
            hi_scores[hi_scores.Length - 1] = score;//assign score the last position of leader board    
        }

        for (i = 0;i<hi_scores.Length;i++)//bubble short
        {
            for (int j = 0; j < hi_scores.Length - 1; j++)
            {
                if (hi_scores[j] < hi_scores[j + 1])
                {
                    temp = hi_scores[j];
                    hi_scores[j] = hi_scores[j+1];
                    hi_scores[j+1] = temp;
                }
            }
        }
        for (i = 0; i < hi_scores.Length; i++)//writing data to file
        {
            scoreVar = "Level" + levelCount.ToString() + "Score" + i.ToString();
            PlayerPrefs.SetInt(scoreVar, hi_scores[i]);
        }
    }

    public void gotoMenu()
    {
        Application.LoadLevel("Menu");
    }

    public void restart()
    {
        Application.LoadLevel("Game");
    }

    public void gotoNextLevel()
    {
        levelCount++;
        PlayerPrefs.SetInt("levelCount", levelCount);
        Application.LoadLevel("Game");
    }

}
