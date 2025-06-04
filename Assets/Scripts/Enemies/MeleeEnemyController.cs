using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private HealthController playerHealth;

    private EnemyPatrolController enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrolController>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
        }

        if(enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<HealthController>();
            return true;
        }

        return false;
    }

    private void DamagePlayer()
    {
        //If player still in hitrange
        if (PlayerInSight() && playerHealth != null)
        {
            playerHealth.Death();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (((1 << collision.gameObject.layer) & playerLayer) != 0)
    {
        playerHealth = collision.GetComponent<HealthController>();
        if (playerHealth != null)
        {
            playerHealth.Death();
        }
    }
}
}
