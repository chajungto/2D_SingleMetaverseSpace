using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject playerName;

    [SerializeField]
    private string replacedName;

    public Vector2 inputVec;        
    public float speed;

    Rigidbody2D rigid;

    [SerializeField]
    GameObject playerModel;

    [SerializeField]
    Animator animator;

    [SerializeField]
    private bool isLeft = true;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

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

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

}
