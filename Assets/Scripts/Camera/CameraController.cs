using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //�÷��̾� ���� ������Ʈ
    [SerializeField]
    private GameObject player;

    //ī�޶� �÷��̾� ���󰡴� �ӵ�?
    [SerializeField]
    private float followSpeed = 0.01f;


    //���� �� Tag�� Player�� �ش��ϴ� GameObject�� ã��
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    //ī�޶��� ��ġ�� ��� �ɷ��̾��� x,y��ǥ�� ����� ����ٴϵ��� �ϱ� / Lerp�� �ε巴�� ���̱� ����
    void FixedUpdate()
    {
        Vector3 cameraPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, cameraPos, followSpeed);
    }
}
