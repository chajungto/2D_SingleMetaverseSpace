using System.Collections;
using System.Collections.Generic;
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
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

}
