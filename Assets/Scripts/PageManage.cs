using UnityEngine;
using UnityEngine.UI;

public class PageManage : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject pageScreen;
    public Image pageImage;

    public Sprite page1;
    public Sprite page2;
    public Sprite page3;
    
    public SoundManager soundManager;
    
    int currentPage = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleScreen.SetActive(true);
        pageScreen.SetActive(false);
        //starts w page 1
        pageImage.sprite = page1;
    }

    public void PressStart()
    {
        titleScreen.SetActive(false);
        pageScreen.SetActive(true);

        //starts on page 1
        currentPage = 1;
        pageImage.sprite = page1;
        
        
    }
    public void NextPage()
    {
        if (currentPage == 1)
        {
            //shows next page
            pageImage.sprite = page2;
            currentPage = 2;
        }
        else if (currentPage == 2)
        {
            pageImage.sprite = page3;
            currentPage = 3;
        }
        else if (currentPage == 3)
        {
            Destroy(gameObject);
        }

        soundManager.PlayButton();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
