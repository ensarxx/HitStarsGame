using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StarGenerator : MonoBehaviour
{
    public int score = 0;

    public TMP_Text scoretext;

    public Text yourScoreText;

    public Text highestScoreText;

    public Text timertext;

    public float remainingTime = 5;

    public GameObject deadPanel;

    public GameObject mainMenuPanel;

    public int uploadScoreInt;
    


    


    void Start()
    {
        deadPanel.SetActive(false);
        PlayerPrefs.SetInt("atishakki", 1);
        Time.timeScale = 1;

        uploadScoreInt = 0;



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        score += 1;
        PlayerPrefs.SetInt("atishakki", 1);
        int starxAxis = Random.Range(-9, 9);
        int staryAxis = Random.Range(-3, 3);
        transform.position = new Vector3(starxAxis, staryAxis, 1.0f);
        remainingTime = 5;
        

    }




    private void Awake()
    {
        
    }


    void Update()
    {

        highestScoreText.text = "Highest Score: " + PlayerPrefs.GetInt("highestscore").ToString() + "";

        bool isCounting = true;

        if (isCounting)
        {
            remainingTime -= Time.deltaTime;
        }

        scoretext.text = "Score: " + score.ToString() + "";
        timertext.text = "Time Remaining: " + ((int)PlayerPrefs.GetFloat("remainingtime")).ToString() + "";
        if (remainingTime <= 0)// dead // remainingTime < 0 olacak // deðþtirildi
        {
            isCounting = false;
            timertext.text = "";
            Time.timeScale = 0;
            deadPanel.SetActive(true);
            yourScoreText.text = "Score: "+score.ToString()+"";
            
        }


        if (score > PlayerPrefs.GetInt("highestscore"))
        {
            PlayerPrefs.SetInt("highestscore", score);
            uploadScoreInt = 1;
            HighScores.UploadScore(PlayerPrefs.GetString("name"), PlayerPrefs.GetInt("highestscore"));
            


        }

        PlayerPrefs.SetFloat("remainingtime", remainingTime);
           

    }

    

    public void replayScene()
    {
        SceneManager.LoadScene("MainScene");
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        
    }
}
