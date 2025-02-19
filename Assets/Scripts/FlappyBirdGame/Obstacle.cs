using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosy = -1f;

    //위와 아래의 장애물 간격
    public float holeMinSize = 1f;
    public float holeMaxSize = 3f;

    //위 아래 장애물
    public Transform topObject;
    public Transform bottomObject;

    //장애물들 사이의 폭
    public float widthPadding = 4f;

    //랜덤위치 장애물 생성
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
