using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject playerName;          //플레이어 이름

    [SerializeField]
    private string replacedName;            //대체 이름

    public Vector2 inputVec;                //이동 벡터
    public float speed;                     //이동 속도
    Rigidbody2D rigid;                      //리지드 바디

    [SerializeField]
    GameObject playerModel;                 //플레이어 모델

    [SerializeField]
    Animator animator;                      //모델의 애니메이터

    [SerializeField]
    public GameObject scriptPanel;           //NPC 대화 패널
    public float radius = 1f;               //감지 범위
    public LayerMask layer;                 //NPC 잡을 레이어

    public Collider2D npcCollider;          //감지될 NPC 콜라이더

    public bool isLeft = true;              //왼쪽으로 이동중인지의 여부
    public bool isAbleToMove = true;        //움직임이 가능한지의 여부
    public bool isAbleToTalk = false;       //대화 가능 여부

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    //플레이어 이름 정하기
    void Start()
    {
        if (PlayerPrefs.GetString("playerName") != "")
        {
            playerName.GetComponent<TextMesh>().text = PlayerPrefs.GetString("playerName");
        }
        else
        {
            playerName.GetComponent<TextMesh>().text = replacedName;
        }
    }


    void Update()
    {
        npcCollider = Physics2D.OverlapCircle(transform.position, radius, layer);
    }

    //반경 그리기(blue)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

        //움직이는 애니메이션 호출
        if (inputVec.x != 0 || inputVec.y != 0)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        //움직일때 좌우 위치 바꾸기(flip)
        if (inputVec.x == 0)
        {
            if (isLeft)
            {
                playerModel.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                playerModel.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (inputVec.x > 0)
        {
            isLeft = false;
            playerModel.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (inputVec.x < 0)
        {
            isLeft = true;
            playerModel.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    //이동
    void OnMove(InputValue value)
    {
        if (isAbleToMove)
        {
            inputVec = value.Get<Vector2>();
        }
    }

    //대화
    void OnTalk()
    {
        if (isAbleToTalk)
        {
            try
            {
                NPCController npcController = npcCollider.GetComponent<NPCController>();

                if (npcController != null)
                {
                    scriptPanel = npcController.scriptPanel;
                    scriptPanel.SetActive(true);
                    isAbleToMove = false; 
                    inputVec = Vector2.zero;
                }
            }
            catch { }
        }
    }

    void OnMoveGameScene()
    {
        if (isAbleToTalk && !isAbleToMove)
        {
            scriptPanel.SetActive(false);
            isAbleToMove = true;

            switch (npcCollider.GetComponent<NPCController>().npcInfo.ID)
            {
                case 1:
                    SceneManager.LoadScene("FindErrorGameScene");
                    break;
                case 2:
                    SceneManager.LoadScene("FindErrorGameScene");
                    break;
                case 3:
                    SceneManager.LoadScene("FindErrorGameScene");
                    break;
                case 4:
                    SceneManager.LoadScene("FindErrorGameScene");
                    break;
                case 5:
                    SceneManager.LoadScene("FlappyBirdGameScene");
                    break;
                case 6:
                    SceneManager.LoadScene("FlappyBirdGameScene");
                    break;
                case 7:
                    SceneManager.LoadScene("FlappyBirdGameScene");
                    break;
                case 8:
                    SceneManager.LoadScene("FlappyBirdGameScene");
                    break;
                default: break;
            }
        }
    }

    //움직임 가능 
    void OnMoveAble()
    {
        if (isAbleToTalk && !isAbleToMove)
        {
            scriptPanel.SetActive(false);
            isAbleToMove = true;
        }
    }
}
