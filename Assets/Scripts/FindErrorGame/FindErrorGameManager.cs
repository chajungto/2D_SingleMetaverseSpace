using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindErrorGameManager : MonoBehaviour
{
    private static FindErrorGameManager instance;        //�̱���

    public static FindErrorGameManager Instance          //�̱��� ������Ƽ
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    [SerializeField]
    List<GameObject> errorCodes = new List<GameObject>();       //�����ڵ��

    public float currentTime = 0f;              //�ð�

    public float routine = 1.5f;                  //�����ֱ�

    public float routineTime = 0f;              //�����ֱ� ����

    public float limitTime = 60f;               //���ѽð�

    public Text TimeTxt;                        //�ð� ǥ��

    public Text ScoreTxt;                       //���� ǥ��

    public Text FinalScoreTxt;                  //�������� ǥ��

    public Text BestScoreTxt;                  //�ְ����� ǥ��

    public int score = 0;                           //����

    public GameObject StartPanel;               //���� �г�

    public GameObject EndPanel;                 //���� �г�

    public GameObject DescriptionPanel;         //���� �г�

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
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

        if (currentTime >= 60)
        {
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
}
