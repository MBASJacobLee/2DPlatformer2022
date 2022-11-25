using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [Header("Player Layer")]
    public LayerMask Enemy;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform attackpos;
    [SerializeField] private float attackrange = 0.5f;
    public int attackDamage = 40;

    public float attackrate = 2f;
    float nextattacktime = 0f;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {

    if(Time.time >= nextattacktime){
        if(Input.GetKeyDown(KeyCode.R))
        {
            Attack();
            nextattacktime = Time.time + 1f / attackrate;
        }
    }
    void Attack()
    {
        anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpos.position, attackrange, Enemy);

        foreach(Collider2D boom in hitEnemies)
        {
            boom.GetComponent<MelleEnemy>().DealDamage(attackDamage);
        }
    }
    }
}
 