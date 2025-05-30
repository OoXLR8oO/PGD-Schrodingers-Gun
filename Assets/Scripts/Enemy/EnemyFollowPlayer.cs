using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public GridManager gridManager;
    public Transform player;
    public float moveSpeed = 2f;
    public float nextWaypointDistance = 0.1f;

    private Pathfinding pathfinding;
    private List<Vector2Int> path;
    private int currentWaypoint = 0;

    private void Start()
    {
        pathfinding = new Pathfinding(gridManager);
        StartCoroutine(UpdatePathRoutine());
    }

    private IEnumerator UpdatePathRoutine()
    {
        while (true)
        {
            UpdatePath();
            yield return new WaitForSeconds(0.5f); // update path twice per second
        }
    }

    private void UpdatePath()
    {
        Vector2Int startGridPos = gridManager.WorldToGrid(transform.position);
        Vector2Int targetGridPos = gridManager.WorldToGrid(player.position);

        path = pathfinding.FindPath(startGridPos, targetGridPos);
        currentWaypoint = 0;
    }

    private void Update()
    {
        if (path == null || path.Count == 0)
            return;

        Vector3 targetPos = gridManager.GridToWorld(path[currentWaypoint]);
        Vector3 dir = (targetPos - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPos) < nextWaypointDistance)
        {
            currentWaypoint++;
            if (currentWaypoint >= path.Count)
            {
                path = null;
            }
        }
    }
}

