using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //플레이어 이름
    [SerializeField]
    private GameObject playerName;

    //대체 이름
    [SerializeField]
    private string replacedName;

    public Vector2 inputVec;        
    public float speed;

    Rigidbody2D rigid;

    //플레이어 모델
    [SerializeField]
    GameObject playerModel;

    //모델의 애니메이터
    [SerializeField]
    Animator animator;

    //왼쪽으로 이동중인지의 여부
    [SerializeField]
    private bool isLeft = true;

    //NPC 대화 패널
    [SerializeField]
    GameObject scriptPanel;

    //움직임이 가능한지의 여부
    [SerializeField]
    private bool isAbleToMove = true;

    //감지 범위
    public float radius = 1f;

    //NPC 잡을 레이어
    public LayerMask layer;

    //감지될 NPC 콜라이더
    public Collider2D npcCollider;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    //플레이어 이름 정하기
    void Start()
    {
        if(PlayerPrefs.GetString("playerName") != "")
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
        if (npcCollider != null)
        {
            Debug.Log("엔피시 감지");
        }
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
        if(inputVec.x != 0 || inputVec.y != 0)
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
        else if(inputVec.x < 0)
        {
            isLeft = true;
            playerModel.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    //이동
    void OnMove(InputValue value)
    {
        if(isAbleToMove)
        {
            inputVec = value.Get<Vector2>();
        }
    }

    //대화
    void OnTalk()
    {
        if (GameManager.Instance.isAbleToTalk)
        {
            for(int i = 1; i <= GameManager.Instance.npcPanel.Count; i++)
            {
                if (npcCollider.GetComponent<NPCController>().npcInfo.ID == i)
                {
                    scriptPanel = npcCollider.GetComponent<NPCController>().scriptPanel;
                }
            }
            
            scriptPanel.SetActive(true);
            isAbleToMove = false;
        }
    }

    //움직임 가능
    void OnMoveAble()
    {
        if (GameManager.Instance.isAbleToTalk && !isAbleToMove)
        {
            scriptPanel.SetActive(false);
            isAbleToMove = true;
        }
    }

}
