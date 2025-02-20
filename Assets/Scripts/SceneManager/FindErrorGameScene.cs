using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FindErrorGameScene : SceneBase
{
    [SerializeField]
    List<GameObject> errorCodes = new List<GameObject>();       //�����ڵ��

    public GameObject StartPanel;               //���� �г�
    public GameObject EndPanel;                 //���� �г�
    public GameObject DescriptionPanel;         //���� �г�

    public int score = 0;                           //����

    public float currentTime = 0f;                  //�ð�
    public float routine = 1.5f;                    //�����ֱ�
    public float routineTime = 0f;                  //�����ֱ� ����
    public float limitTime = 60f;                   //���ѽð�

    public Text TimeTxt;                            //�ð� ǥ��
    public Text ScoreTxt;                           //���� ǥ��
    public Text FinalScoreTxt;                      //�������� ǥ��
    public Text BestScoreTxt;                       //�ְ����� ǥ��


    protected override void Start()
    {
        InitScene();
        StartPanel.SetActive(true);
        EndPanel.SetActive(false);
        BestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString();
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Time.timeScale == 1f)
        {
            currentTime += Time.deltaTime;
            routineTime += Time.deltaTime;
        }
        TimeTxt.text = string.Format("{0:N2}", currentTime);
        ScoreTxt.text = score.ToString();
        FinalScoreTxt.text = score.ToString();

        if (currentTime >= limitTime)
        {
            currentTime = 0f;
            EndPanel.SetActive(true);
            Time.timeScale = 0f;
            if (score > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", score);
                BestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString();
            }

        }

        if (currentTime >= 30f)
        {
            routine = 1f;
        }

        int randomIndex = Random.Range(0, errorCodes.Count);
        float xPos = Random.Range(-9.65f, 9.65f);
        float yPos = Random.Range(-3.8f, 3.8f);

        int randomNumber = Random.Range(0, errorCodes.Count);
        if (routineTime >= routine)
        {
            GameObject errorCode = Instantiate(errorCodes[randomIndex], new Vector2(xPos, yPos), Quaternion.identity);
            Destroy(errorCode, 3f);
            routineTime = 0f;
        }
    }

    //���� ����
    public void OnStartGame()
    {
        StartPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    //���� �ٽ��ϱ�
    public void OnRetryGame()
    {
        SceneManager.LoadScene("FindErrorGameScene");
    }

    //���� ������
    public void OnExitGame()
    {
        SceneManager.LoadScene("Mainscene");
    }

    //���� �г� �����ֱ�
    public void OnShowDiscription()
    {
        DescriptionPanel.SetActive(true);
    }

    //���� �г� �ݱ�
    public void OnCloseDiscription()
    {
        DescriptionPanel.SetActive(false);
    }
}
