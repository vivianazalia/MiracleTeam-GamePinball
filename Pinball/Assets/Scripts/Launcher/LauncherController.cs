using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField]
    private Collider ball;
    [SerializeField]
    private KeyCode input;
    [SerializeField]
    private float maxForce;
    [SerializeField]
    private float maxTimeHold;

    private bool isHold;

    private void Start()
    {
        isHold = false;
    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider == ball)
        {
            ReadInput(ball);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0f;
        float timeHold = 0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);
            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
    }
}
