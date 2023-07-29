using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpawner : MonoBehaviour
{
    [System.Serializable]
    private class SpawnPosition
    {
        public Transform position;
        public bool empty;
    }

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private List<SpawnPosition> spawnTransform = new List<SpawnPosition>();

    [SerializeField] private int count;

    public static UnityAction OnChangeCoinCount;
    public static UnityAction<Vector3> OnEmptySpawnPosition;

    private void Awake()
    {
        OnChangeCoinCount += CoinDestroy;
        OnEmptySpawnPosition += EmptyPosition;
    }

    private void OnDestroy()
    {
        OnChangeCoinCount -= CoinDestroy;
        OnEmptySpawnPosition -= EmptyPosition;
    }

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

    private void CoinDestroy()
    {
        count--;
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

    private void EmptyPosition(Vector3 position)
    {
        foreach(var spawn in spawnTransform)
        {
            if(spawn.position.position == position)
            {
                spawn.empty = true;
            }
        }
    }
}
