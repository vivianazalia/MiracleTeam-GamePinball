using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;

    Animator animator;
    Renderer bumperRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        bumperRenderer = GetComponent<Renderer>();

        bumperRenderer.material.color = color;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRb = bola.GetComponent<Rigidbody>();
            bolaRb.velocity *= multiplier;

            animator.SetTrigger("hit");
        }
    }
}
