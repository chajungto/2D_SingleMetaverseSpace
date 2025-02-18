using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindErrorGameManager : MonoBehaviour
{
    private static FindErrorGameManager instance;        //싱글톤

    public static FindErrorGameManager Instance          //싱글톤 프로퍼티
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
    List<GameObject> errorCodes = new List<GameObject>();       //오류코드들

    public float currentTime = 0f;              //시간

    public float routine = 1.5f;                  //생성주기

    public float routineTime = 0f;              //생성주기 측정

    public float limitTime = 60f;               //제한시간

    public Text TimeTxt;                        //시간 표시

    public Text ScoreTxt;                       //점수 표시

    public Text FinalScoreTxt;                  //최종점수 표시

    public Text BestScoreTxt;                  //최고점수 표시

    public int score = 0;                           //점수

    public GameObject StartPanel;               //시작 패널

    public GameObject EndPanel;                 //종료 패널

    public GameObject DescriptionPanel;         //설명 패널

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
