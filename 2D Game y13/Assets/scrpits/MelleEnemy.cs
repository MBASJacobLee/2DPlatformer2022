using UnityEngine;

public class MelleEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] private int maxhealth = 3;
    int currentHealth;

    //References
    [SerializeField]private Animator anim;
    private Health playerHealth;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        currentHealth = maxhealth;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("melee_attack");
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    //checking if the player is in sight
    private bool PlayerInSight()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;
    }

    //this is a debuging thing to tell where the enemy can see
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    //damages the player
    private void DamagePlayer()
    {
        if (PlayerInSight())
        //calling another function, from another script
            playerHealth.TakeDamage(damage);
    }

    //enemy taking damage
    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    // if enemy dies
    void Die()
    {
        Debug.Log("death");
        anim.SetTrigger("die");

        GetComponent<Collider2D>().enabled = false;
        GetComponentInParent<EnemyPatrol>().enabled = false;
        GetComponent<MelleEnemy>().enabled = false;
    }
}