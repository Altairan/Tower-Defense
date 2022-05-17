using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float startSpeed = 10;
    [HideInInspector]
    public float speed;

   
    public float health = 100;
    public int moneyGained = 100;
    public GameObject deathEffect;
   
    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
       GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        PlayerStats.Money += moneyGained;
        Destroy(gameObject);
    }

    
}
