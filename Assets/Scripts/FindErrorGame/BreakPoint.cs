using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BreakPoint : MonoBehaviour
{
    public Vector2 inputVec;                //�̵� ����

    public float speed;                     //�̵� �ӵ�

    Rigidbody2D rigid;                      //������ �ٵ�

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    //�̵�
    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

}
