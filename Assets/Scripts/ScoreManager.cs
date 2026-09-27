using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    //keeps track or score + highscore
    int score = 0;

    int highScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if no saved high score - uses 0 instead
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        //sets reg score on screen
        scoreText.text = "Score: 0";
        //displays highscore
        highScoreText.text = "Highscore: " + highScore;
        
    }

    public void AddScore(int points)
    {
        score += points;

        if (score > highScore)
        {
            highScore = score;
            //saves high score if game closed
            PlayerPrefs.SetInt("HighScore", highScore);
            //confirms high score is saved
            PlayerPrefs.Save();
        }
        //updates
        scoreText.text = "Score: " + score;
        highScoreText.text = "HighScore: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
