using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    
    public static LevelGrid Instance { get; private set; }
    
    [SerializeField] private Transform gridDebugObjectPrefab;
    
    private GridSystem gridSystem;
    
    private void Awake()
    {
        
        if (Instance != null)
        {
            Debug.LogError("iki instance var"+transform+" - "+Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        
        gridSystem = new GridSystem(10, 10,2f); // dikkat
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
      GridObject gridObject =  gridSystem.GetGridObject(gridPosition);
      gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject =  gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject =  gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void UnitMovedGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
    {
        RemoveUnitAtGridPosition(fromGridPosition, unit);
        
        AddUnitAtGridPosition(toGridPosition, unit);
    }
    
    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
    
    
}
