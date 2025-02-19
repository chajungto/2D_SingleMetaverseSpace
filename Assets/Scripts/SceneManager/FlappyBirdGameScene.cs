using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyBirdGameScene : SceneBase
{
    public float playTime;
 
    public Text playTimeTxt;

    public Text finalTimeTxt;

    public Text bestPlayTimeTxt;

    void Start()
    {
        Time.timeScale = 0f;
        InitScene();
        flappyStartPanel.SetActive(true);
        flappyEndPanel.SetActive(false);
    }

    void InitScene()
    {
        GameManager.Instance.currentScene = this;
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
    }
}
