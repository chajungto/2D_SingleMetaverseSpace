using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    //장애물 카운트
    public int obstacleCount = 0;

    //블럭 카운트
    public int blockCount = 17;

    //배경 카운트
    public int numBgCount = 5;

    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();

        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }

        if (collision.CompareTag("Boundary"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * blockCount * numBgCount;
            collision.transform.position = pos;

            //Debug.Log(pos);
            return;
        }
    }
}
