using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BreakPoint : MonoBehaviour
{
    public Vector2 inputVec;                //이동 벡터

    public float speed;                     //이동 속도

    Rigidbody2D rigid;                      //리지드 바디

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

    //이동
    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

}
