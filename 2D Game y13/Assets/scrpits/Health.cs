using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;
    private Rigidbody2D rb;
    [SerializeField] private GameOverScreen go;

    private void Awake()
    {
    currentHealth = startingHealth;
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    }
    
    //player health this gets called from the mellee enemy scprit
    public void TakeDamage(float _damage)
    {
    currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
    if (currentHealth > 0)
    {
        anim.SetTrigger("hurt");
    }
    else
    {
        //if the player dies it will end the game
        if (!dead)
        {
            anim.SetTrigger("die");
            //rb.bodyType = Rigidbody2D.Static;
            dead = true;
            go.loss();
        }
    }
    }
}
