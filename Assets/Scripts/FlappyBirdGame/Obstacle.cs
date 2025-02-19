using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosy = -1f;

    //���� �Ʒ��� ��ֹ� ����
    public float holeMinSize = 1f;
    public float holeMaxSize = 3f;

    //�� �Ʒ� ��ֹ�
    public Transform topObject;
    public Transform bottomObject;

    //��ֹ��� ������ ��
    public float widthPadding = 4f;

    //������ġ ��ֹ� ����
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstaclecount)
    {
        float holeSize = Random.Range(holeMinSize, holeMaxSize);
        float halfHoleSize = holeSize / 2f;

        topObject.localPosition = new Vector3(0, halfHoleSize + 2f);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosy, highPosY);

        transform.position = placePosition;
        return placePosition;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
