using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pathfinding : MonoBehaviour, ICustomUpdate
{
    [SerializeField] private Tilemap _level;
    [SerializeField] private GameObject _target;

    public void CustomUpdate()
    {
        // _level.GetCellCenterLocal
        transform.position = GetNextPositionInPathToTarget(_level.WorldToCell(_target.transform.position));
    }

    private Vector3Int GetNextPositionInPathToTarget(Vector3Int target)
    {
        var _startPosition = _level.WorldToCell(transform.position);
        var _openList = new Queue<Vector3Int>();
        var _closeList = new List<Vector3Int>();

        _openList.Enqueue(target);
        _closeList.Add(target);

        while (_openList.Count > 0)
        {
            var currentPosition = _openList.Dequeue();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x != 0 && y != 0)
                        continue;

                    var researchedPoint = currentPosition + new Vector3Int(x, y, 0);

                    if (_level.GetTile(researchedPoint) != null)
                    {
                        continue;
                    }
                    
                    if (_closeList.Contains(researchedPoint))
                    {
                        continue;
                    }
                        

                    if (researchedPoint == _startPosition)
                    {
                        return currentPosition;
                    }
                       

                    _openList.Enqueue(researchedPoint);
                    _closeList.Add(researchedPoint);  
                }                
            }   
        }
        return _startPosition;      
    }
}
