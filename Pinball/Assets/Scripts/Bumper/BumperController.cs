using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;

    [SerializeField]
    private List<Color> colors = new List<Color>();

    private Animator animator;
    private Renderer bumperRenderer;
    private int currentIndex;

    void Start()
    {
        animator = GetComponent<Animator>();
        bumperRenderer = GetComponent<Renderer>();

        currentIndex = 0;
        bumperRenderer.material.color = colors[currentIndex];
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRb = bola.GetComponent<Rigidbody>();
            bolaRb.velocity *= multiplier;

            currentIndex++;
            if (currentIndex > 2)
            {
                currentIndex = 0;
            }

            animator.SetTrigger("hit");
            bumperRenderer.material.color = colors[currentIndex];
        }
    }
}
