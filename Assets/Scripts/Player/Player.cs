using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //�÷��̾� �̸�
    [SerializeField]
    private GameObject playerName;

    //��ü �̸�
    [SerializeField]
    private string replacedName;

    public Vector2 inputVec;        
    public float speed;

    Rigidbody2D rigid;

    //�÷��̾� ��
    [SerializeField]
    GameObject playerModel;

    //���� �ִϸ�����
    [SerializeField]
    Animator animator;

    //�������� �̵��������� ����
    [SerializeField]
    private bool isLeft = true;

    //NPC ��ȭ �г�
    [SerializeField]
    GameObject scriptPanel;

    //�������� ���������� ����
    [SerializeField]
    private bool isAbleToMove = true;

    //���� ����
    public float radius = 1f;

    //NPC ���� ���̾�
    public LayerMask layer;

    //������ NPC �ݶ��̴�
    public Collider2D npcCollider;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    //�÷��̾� �̸� ���ϱ�
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
            Debug.Log("���ǽ� ����");
        }
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
        if(inputVec.x != 0 || inputVec.y != 0)
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
        else if(inputVec.x < 0)
        {
            isLeft = true;
            playerModel.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    //�̵�
    void OnMove(InputValue value)
    {
        if(isAbleToMove)
        {
            inputVec = value.Get<Vector2>();
        }
    }

    //��ȭ
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

    //������ ����
    void OnMoveAble()
    {
        if (GameManager.Instance.isAbleToTalk && !isAbleToMove)
        {
            scriptPanel.SetActive(false);
            isAbleToMove = true;
        }
    }

}
