using UnityEngine;

public class RisingWallController : MonoBehaviour
{
    [Header("Movement Positions")]
    [SerializeField] private Transform upPosition;
    [SerializeField] private Transform downPosition;

    [Header("Obstacle Settings")]
    [SerializeField] private Transform obstacle; // The moving obstacle
    [SerializeField] private float speed = 2f;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration = 1f;
    private float idleTimer;

    private bool movingUp = true;
    private bool isIdle;

    [Header("Optional Animator")]
    [SerializeField] private Animator anim;

    private void Update()
    {
        if (isIdle)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleDuration)
            {
                isIdle = false;
                movingUp = !movingUp;
            }
            return;
        }

        MoveObstacle();
    }

    private void MoveObstacle()
    {
        Vector3 target = movingUp ? upPosition.position : downPosition.position;
        obstacle.position = Vector3.MoveTowards(obstacle.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(obstacle.position, target) <= 0.01f)
        {
            isIdle = true;
            idleTimer = 0f;

            if (anim != null)
                anim.SetTrigger("Idle"); // Optional animation trigger
        }
    }
}
