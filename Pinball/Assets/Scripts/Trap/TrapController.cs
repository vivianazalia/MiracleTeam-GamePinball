using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyCoin(10));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bola")
        {
            other.GetComponent<BallController>().ResetPosition();
            gameObject.SetActive(false);
            SpawnerManager.OnChangeCoinCount?.Invoke("Trap");
            SpawnerManager.OnEmptySpawnPosition?.Invoke(transform.position, "Trap");
        }
    }

    private IEnumerator DestroyCoin(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        SpawnerManager.OnChangeCoinCount?.Invoke("Trap");
        SpawnerManager.OnEmptySpawnPosition?.Invoke(transform.position, "Trap");
    }
}
