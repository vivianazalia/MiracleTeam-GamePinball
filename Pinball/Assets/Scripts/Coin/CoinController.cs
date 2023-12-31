using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyCoin(10));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bola")
        {
            gameObject.SetActive(false);
            SpawnerManager.OnChangeCoinCount?.Invoke("Coin");
            SpawnerManager.OnEmptySpawnPosition?.Invoke(transform.position, "Coin");
        }
    }

    private IEnumerator DestroyCoin(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        SpawnerManager.OnChangeCoinCount?.Invoke("Coin");
        SpawnerManager.OnEmptySpawnPosition?.Invoke(transform.position, "Coin");
    }
}
