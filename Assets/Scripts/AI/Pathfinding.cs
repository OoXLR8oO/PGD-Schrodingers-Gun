using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private GridManager gridManager;

    public Pathfinding(GridManager gridManager)
    {
        this.gridManager = gridManager;
    }

    private class Node
    {
        public Vector2Int position;
        public Node parent;
        public int gCost; // cost from start to this node
        public int hCost; // heuristic cost to end
        public int FCost => gCost + hCost;

        public Node(Vector2Int pos)
        {
            position = pos;
        }
    }

    public List<Vector2Int> FindPath(Vector2Int startPos, Vector2Int targetPos)
    {
        var openSet = new List<Node>();
        var closedSet = new HashSet<Vector2Int>();

        Node startNode = new Node(startPos);
        startNode.gCost = 0;
        startNode.hCost = GetHeuristic(startPos, targetPos);

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            // Get node with lowest FCost
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].FCost < currentNode.FCost ||
                    (openSet[i].FCost == currentNode.FCost && openSet[i].hCost < currentNode.hCost))
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode.position);

            if (currentNode.position == targetPos)
            {
                return RetracePath(currentNode);
            }

            foreach (var neighbourPos in GetNeighbours(currentNode.position))
            {
                if (closedSet.Contains(neighbourPos) || !gridManager.IsWalkable(neighbourPos))
                    continue;

                int tentativeGCost = currentNode.gCost + 1; // assume cost between neighbours = 1

                Node neighbourNode = openSet.Find(n => n.position == neighbourPos);
                if (neighbourNode == null)
                {
                    neighbourNode = new Node(neighbourPos);
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = GetHeuristic(neighbourPos, targetPos);
                    neighbourNode.parent = currentNode;
                    openSet.Add(neighbourNode);
                }
                else if (tentativeGCost < neighbourNode.gCost)
                {
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.parent = currentNode;
                }
            }
        }

        return null; // no path found
    }

    private List<Vector2Int> RetracePath(Node endNode)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        Node current = endNode;

        while (current != null)
        {
            path.Add(current.position);
            current = current.parent;
        }
        path.Reverse();
        return path;
    }

    private int GetHeuristic(Vector2Int a, Vector2Int b)
    {
        // Manhattan distance (no diagonal movement)
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    private List<Vector2Int> GetNeighbours(Vector2Int node)
    {
        List<Vector2Int> neighbours = new List<Vector2Int>();

        Vector2Int[] directions = new Vector2Int[]
        {
            new Vector2Int(0,1), // up
            new Vector2Int(0,-1), // down
            new Vector2Int(1,0), // right
            new Vector2Int(-1,0), // left
        };

        foreach (var dir in directions)
        {
            Vector2Int neighbourPos = node + dir;
            if (neighbourPos.x >= 0 && neighbourPos.x < gridManager.gridSize.x &&
                neighbourPos.y >= 0 && neighbourPos.y < gridManager.gridSize.y)
            {
                neighbours.Add(neighbourPos);
            }
        }

        return neighbours;
    }
}
