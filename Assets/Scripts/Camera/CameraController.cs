using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //플레이어 게임 오브젝트
    [SerializeField]
    private GameObject player;

    //카메라가 플레이어 따라가는 속도?
    [SerializeField]
    private float followSpeed = 0.01f;


    //시작 전 Tag가 Player에 해당하는 GameObject를 찾음
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    //카메라의 위치를 계속 믈레이어의 x,y좌표로 만들어 따라다니도록 하기 / Lerp는 부드럽게 보이기 위함
    void FixedUpdate()
    {
        Vector3 cameraPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, cameraPos, followSpeed);
    }
}
