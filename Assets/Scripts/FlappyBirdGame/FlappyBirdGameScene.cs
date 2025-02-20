using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyBirdGameScene : SceneBase
{
    public Bird bird;

    public GameObject flappyStartPanel;

    public GameObject flappyEndPanel;

    public float playTime;
 
    public Text playTimeTxt;

    public Text finalTimeTxt;

    public Text bestPlayTimeTxt;

    protected override void Start()
    {
        Time.timeScale = 0f;
        InitScene();
        flappyStartPanel.SetActive(true);
        flappyEndPanel.SetActive(false);
    }

    private void Update()
    {
        if(Time.timeScale == 1f)
        {
            playTime += Time.deltaTime;
            playTimeTxt.text = string.Format("{0:N2}", playTime);
            finalTimeTxt.text = string.Format("{0:N2}", playTime);
        }
        else
        {
            if(playTime > PlayerPrefs.GetFloat("BestPlayTime"))
            {
                PlayerPrefs.SetFloat("BestPlayTime", playTime);
                
            }
        }
        bestPlayTimeTxt.text = string.Format("{0:N2}", PlayerPrefs.GetFloat("BestPlayTime"));

        if(bird.isDead)
        {
            flappyEndPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    //게임 시작
    public void OnStartGame()
    {
        flappyStartPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    //게임 다시하기
    public void OnRetryGame()
    {
        SceneManager.LoadScene("FlappyBirdGameScene");
    }

    public void OnExitGame()
    {
        SceneManager.LoadScene("Mainscene");
    }
}
