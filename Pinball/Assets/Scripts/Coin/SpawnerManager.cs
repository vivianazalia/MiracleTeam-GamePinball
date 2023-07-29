using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private List<Spawner> spawners = new List<Spawner>();

    public static UnityAction<string> OnChangeCoinCount;
    public static UnityAction<Vector3, string> OnEmptySpawnPosition;

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

    private void CoinDestroy(string type)
    {
        switch (type)
        {
            case "Coin":
                DecreaseCountSpawner(SpawnerType.Coin);
                break;
            case "Trap":
                DecreaseCountSpawner(SpawnerType.Trap);
                break;
        }
    }

    private void EmptyPosition(Vector3 position, string type)
    {
        switch (type)
        {
            case "Coin":
                SetEmptyPosition(position, SpawnerType.Coin);
                break;
            case "Trap":
                SetEmptyPosition(position, SpawnerType.Trap);
                break;
        }
    }

    private void DecreaseCountSpawner(SpawnerType type)
    {
        foreach(var spawner in spawners)
        {
            if(spawner.Type == type)
            {
                spawner.Count--;
            }
        }
    }

    private void SetEmptyPosition(Vector3 pos, SpawnerType type)
    {
        foreach (var spawner in spawners)
        {
            if (spawner.Type == type)
            {
                foreach (var spawn in spawner.Positions)
                {
                    if (spawn.position.position == pos)
                    {
                        spawn.empty = true;
                        break;
                    }
                }
            }
        }
    }
}
