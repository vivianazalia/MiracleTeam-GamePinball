using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;

    float targetPressed;
    float targetReleased;

    HingeJoint hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        targetPressed = hinge.limits.max;
        targetReleased = hinge.limits.min;
    }

    void Update()
    {
        ReadInput();
    }

    void ReadInput()
    {
        JointSpring jointSpring = hinge.spring;

        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetReleased;
        }

        hinge.spring = jointSpring;
    }
}
