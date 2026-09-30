using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public Image Heart1;

    public Image Heart2;
    public Image Heart3;
    
    public Sprite fullHeart;

    public Sprite emptyHeart;

    public GameObject gameOverCanvas;
    int lives = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHearts();
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateHearts();

            if (lives == 0)
            {
                gameOverCanvas.SetActive(true);
            }
        }
    }

    //gain life event
    public void GainLife()
    {
        if (lives < 3)
        {
            lives++;
            UpdateHearts();
        }
    }

    //restarts whole game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void UpdateHearts()
    {
        Heart1.sprite = lives >= 3 ? fullHeart : emptyHeart;
        Heart2.sprite = lives >= 2 ? fullHeart : emptyHeart;
        Heart3.sprite = lives >= 1 ? fullHeart : emptyHeart;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
