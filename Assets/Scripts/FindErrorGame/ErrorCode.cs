using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ErrorCode : MonoBehaviour
{
    public List<Collider2D> lines = new List<Collider2D>();            //검출될 라인들의 충돌

    public FindErrorGameScene fe;

    void Start()
    {
        fe = FindObjectOfType<FindErrorGameScene>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        lines.Add(collider);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        lines.Remove(collider);
    }

    private void OnRemove()
    {
        if (lines.Count == 2)
        { 
            Destroy(this.gameObject);
            fe.score++;
        }
    }
}
