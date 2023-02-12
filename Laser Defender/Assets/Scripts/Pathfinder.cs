using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> wayPoints;
    int waypointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[waypointIndex].position;
    }
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[waypointIndex].position;
            float delta = waveConfig.GetmoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
                waypointIndex++;
        }
        else{
            Destroy(gameObject);
        }
    }
}
