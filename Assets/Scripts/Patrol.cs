using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform patrolPath;
    public float movementSpeed = 20;

    public List<Transform> patrolPoints;
    private int currentPoint;

    private Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        patrolPoints = GetPathChildren();
        currentPoint = 0;
    }

    List<Transform> GetPathChildren()
    {
        Transform[] results = patrolPath.GetComponentsInChildren<Transform>();
        List<Transform> points = new List<Transform>(results);
        foreach (Transform item in points)
        {
            if (item.parent != patrolPath)
            {
                points.Remove(item);
                break;
            }
        }
        return points;
    }

    
    // Update is called once per frame
    void Update()
    {
        if(transform.position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
        }

        if (currentPoint >= patrolPoints.Count)
        {
            currentPoint = 0;
        }

        rigid.MovePosition(Vector3.MoveTowards(rigid.position,
            patrolPoints[currentPoint].position, movementSpeed * Time.deltaTime));
    }
}
