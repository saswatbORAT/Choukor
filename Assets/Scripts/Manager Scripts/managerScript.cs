using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class managerScript : MonoBehaviour {
    
    public GameObject centerPaddle;
    paddleScript _paddleScript;

    public GameObject textManager;
    public textManagerScript _textManagerScript;

    public GameObject levelManager;
    public levelManagerScript _levelManagerScript;

    public GameObject ball;
    ballScript _ballScript;
    public Vector3 ballPos;
    Vector3 ballSpeed;

    int score;  
    int lives;

    bool isPause;
    public bool startGame;

    int bricks;

    Vector3 center;
	// Use this for initialization
	void Start () {
        center = Vector3.zero;
        isPause = false;
        startGame = false;
        score = 0;
        lives = 3;
        bricks = 0;

        _levelManagerScript = levelManager.GetComponent<levelManagerScript>();
        _levelManagerScript.loadLevel();

        _textManagerScript = textManager.GetComponent<textManagerScript>();
        _textManagerScript.livesText.text = "Lives : " + lives.ToString();

        ballPos = ball.transform.position;
        _ballScript = ball.GetComponent<ballScript>();
        _paddleScript = centerPaddle.GetComponent<paddleScript>();

	}

   

    public void reset()//sets the ball and paddles to their initial position
    {
        _textManagerScript.InstructText.text = "Press Space";
        startGame = false;

        lives--;
        _textManagerScript.livesText.text = "Lives : " + lives.ToString();
        centerPaddle.transform.eulerAngles = Vector3.zero;

        ball.transform.position = ballPos;
        ball.transform.eulerAngles = Vector3.zero;
        ball.transform.parent = centerPaddle.transform;
        _ballScript.multiplier = 1;

        if (lives == 0)
        {
            gotoGameOver();
        }
    }

    public void restart()
    {//
        Application.LoadLevel("Game");
    }

    void gotoGameOver()
    {
        PlayerPrefs.SetInt("currentScore", score);
        Application.LoadLevel("gameOver");
    }

    public void pause()
    {
        _textManagerScript.InstructText.text = "Paused";
        _ballScript.release = false;

        ballSpeed = _ballScript.speed;

        _ballScript.speed = Vector3.zero;

        _paddleScript.released = false;

        _textManagerScript.Panel.SetActive(true);
        _levelManagerScript.currentLevel.SetActive(false);
        isPause = true;
    }

    public void resume()
    {
        _textManagerScript.InstructText.text = "";
        _paddleScript.released = true;
        if (startGame)
        {            
            _ballScript.release = true;
            if (ballSpeed != Vector3.zero)
            {
                _ballScript.speed = ballSpeed;
            }
            else
            {
                _ballScript.speed.x = Mathf.Cos(_ballScript.Angle(ball.transform.position, center) * Mathf.Deg2Rad);
                _ballScript.speed.y = Mathf.Sin(_ballScript.Angle(ball.transform.position, center) * Mathf.Deg2Rad);
            } 
        }
        else
        {
            _textManagerScript.InstructText.text = "Press Space";
        }
        _textManagerScript.Panel.SetActive(false);
        _levelManagerScript.currentLevel.SetActive(true);
        isPause = false;
    }

    public void gotoMenu()
    {
        Application.LoadLevel("Menu");    
    }

    public void checkScore(int multiplier)//increases score
    {
        bricks++;

        _ballScript.speedDifference -= 0.1f;
        score += 100*multiplier;
        _textManagerScript.scoreText.text = "Score : " + score.ToString();
        audio.Play();
        print(audio.isPlaying);
        if (bricks == _levelManagerScript.brickCount)
        {
            gotoGameOver();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))//////
        {
            if (!isPause)
            {
                pause();
            }
            else
            {
                resume();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (!isPause && !startGame)//releases the ball if the game is not paused
            {
             //   ball.transform.eulerAngles = Vector3.zero;
                ball.transform.parent = null;
                startGame = true;
                resume();
            }
        }
    }
}
//