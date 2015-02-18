using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textManagerScript : MonoBehaviour {

    public GameObject Instructions;
    public Text InstructText;

    public GameObject livesGameObject;
    public Text livesText;

    public GameObject ScoreGameObject;
    public Text scoreText;

    public GameObject Multiplier;
    public Text MultiplierText;

    public GameObject Frames;
    public Text FramesText;

    public GameObject Panel;

    bool show;
	// Use this for initialization
	void Awake () {
        initText();
	}

    void initText()
    {
        scoreText = ScoreGameObject.GetComponent<Text>();

        InstructText = Instructions.GetComponent<Text>();
        InstructText.text = "Press Space";

        livesText = livesGameObject.GetComponent<Text>();

        MultiplierText = Multiplier.GetComponent<Text>();

        FramesText = Frames.GetComponent<Text>();
        StartCoroutine("showFrames");
    }

    IEnumerator showFrames()//displays frame-rate every 0.5 seconds
    {
        if (show)
        {
            FramesText.text = "F : " + (1 / Time.deltaTime).ToString();//
        }
        else
        {
            FramesText.text = "";
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("showFrames");
    }
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (show)
            {
                show = false;
                return;
            }
            else
            {
                show = true;
            }
        }
	}
}
