using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Path and Wave", menuName = "New Wave")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] float timeWaitSpawn = 1f;
    [SerializeField] List<GameObject> enemyPrefabs;
    public Transform pathPrefab;
    [SerializeField] private float moveSpeed = 5f;
    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public float GetSpawnerTime()
    {
        return timeWaitSpawn;
    }
}
