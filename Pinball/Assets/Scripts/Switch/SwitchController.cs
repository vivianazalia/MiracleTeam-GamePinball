using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        On, 
        Off,
        Blink
    }

    private SwitchState state;
    private Renderer renderer;

    [SerializeField]
    private Material onMaterial;
    [SerializeField]
    private Material offMaterial;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        Set(false);
        BlinkTimeStart(5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bola")
        {
            Toggle();
        }
    }

    private void Set(bool active)
    {
        if (active)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimeStart(5));
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;
        int blinkTimes = times * 2;
        for(int i = 0; i < blinkTimes; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(.5f);
        }

        state = SwitchState.Off;
        StartCoroutine(BlinkTimeStart(5));
    }

    private IEnumerator BlinkTimeStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

    private void Toggle()
    {
        if(state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }
}
