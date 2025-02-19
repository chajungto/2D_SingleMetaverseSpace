using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;            //점프하는 힘

    public float forwardSpeed = 3f;          //속도

    public bool isDead = false;             //죽음 여부

    private float deathCoolDown = 999f;       //데스 쿨 

    private bool isFlap = false;            //점프 여부

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDead)
        {
            if (deathCoolDown <= 0)
            {
                SceneManager.LoadScene("MainScene");
            }
            else
            {
                deathCoolDown -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }
        else
        {
            //앞으로 전진 & 점프
            Vector3 velocity = _rigidbody.velocity;
            velocity.x = forwardSpeed;
            if (isFlap)
            {
                velocity.y += flapForce;
                isFlap = false;
            }

            _rigidbody.velocity = velocity;

            //회전
            float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    //점프
    void OnFlap()
    {
        if (isDead)
        {
            return;
        }
        else
        {
            isFlap = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        GameManager.Instance.currentScene.flappyEndPanel.SetActive(true);
        Time.timeScale = 0f;

    }


}
