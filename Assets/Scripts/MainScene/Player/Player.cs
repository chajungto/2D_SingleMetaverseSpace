using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject playerName;          //�÷��̾� �̸�

    [SerializeField]
    private string replacedName;            //��ü �̸�

    public Vector2 inputVec;                //�̵� ����
    public float speed;                     //�̵� �ӵ�
    Rigidbody2D rigid;                      //������ �ٵ�

    [SerializeField]
    GameObject playerModel;                 //�÷��̾� ��

    [SerializeField]
    Animator animator;                      //���� �ִϸ�����

    [SerializeField]
    public GameObject scriptPanel;           //NPC ��ȭ �г�
    public float radius = 1f;               //���� ����
    public LayerMask layer;                 //NPC ���� ���̾�

    public Collider2D npcCollider;          //������ NPC �ݶ��̴�

    public bool isLeft = true;              //�������� �̵��������� ����
    public bool isAbleToMove = true;        //�������� ���������� ����
    public bool isAbleToTalk = false;       //��ȭ ���� ����

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    //�÷��̾� �̸� ���ϱ�
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

    //�ݰ� �׸���(blue)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

        //�����̴� �ִϸ��̼� ȣ��
        if (inputVec.x != 0 || inputVec.y != 0)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        //�����϶� �¿� ��ġ �ٲٱ�(flip)
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

    //�̵�
    void OnMove(InputValue value)
    {
        if (isAbleToMove)
        {
            inputVec = value.Get<Vector2>();
        }
    }

    //��ȭ
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

    //������ ���� 
    void OnMoveAble()
    {
        if (isAbleToTalk && !isAbleToMove)
        {
            scriptPanel.SetActive(false);
            isAbleToMove = true;
        }
    }
}
