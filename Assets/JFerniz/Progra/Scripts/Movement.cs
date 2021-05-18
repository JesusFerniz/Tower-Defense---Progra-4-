using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] float distanceTreshold = 0.25f;

    private WayPointPath path;
    private Transform[] waypoints;
    private int targetWaypoingIndex;
    private Transform target;

    public void SetPath(WayPointPath path)
    {
        this.path = path;

        waypoints = path.GetWayPoints();
        targetWaypoingIndex = 0;
        target = waypoints[targetWaypoingIndex];
        transform.position = waypoints[targetWaypoingIndex].position;
    }

    void Update()
    {
        if (target == null) return;

        transform.LookAt(target.position);

        Vector3 direction = waypoints[targetWaypoingIndex].position - transform.position;
        direction = direction.normalized;

        transform.position += direction * Time.deltaTime * speed;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < 0.25f)
        {
            targetWaypoingIndex++;
            if (targetWaypoingIndex < waypoints.Length)
            {
                target = waypoints[targetWaypoingIndex];
            }
            else
            {
                target = null;
            }
        }
    }
}