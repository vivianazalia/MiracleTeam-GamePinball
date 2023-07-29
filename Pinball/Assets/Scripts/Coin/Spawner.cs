using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private SpawnerType type;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private List<SpawnPosition> spawnTransform = new List<SpawnPosition>();

    [SerializeField] private int count;

    public SpawnerType Type { get => type; }
    public int Count { get => count; set => count = value; }
    public List<SpawnPosition> Positions { get => spawnTransform; }

    private void Start()
    {
        InvokeRepeating("Spawn", 0, 3);
    }

    private void Spawn()
    {
        if(count < 3)
        {
            SpawnPosition spawn = CheckEmptySpawnerPosition();
            Instantiate(prefab, spawn.position.position, prefab.transform.rotation);
            FillPosition(spawn);
            count++;
        }
    }

    private SpawnPosition CheckEmptySpawnerPosition()
    {
        SpawnPosition position = new SpawnPosition();

        foreach(var pos in spawnTransform)
        {
            if (pos.empty)
            {
                position = pos;
                break;
            }
        }

        return position;
    }

    private void FillPosition(SpawnPosition pos)
    {
       foreach(var spawn in spawnTransform)
        {
            if(spawn.position == pos.position)
            {
                spawn.empty = false;
            }
        }
    }
}

public enum SpawnerType
{
    Coin,
    Trap
}

[System.Serializable]
public class SpawnPosition
{
    public Transform position;
    public bool empty;
}