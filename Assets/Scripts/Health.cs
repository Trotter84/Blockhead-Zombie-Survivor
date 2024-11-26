using UnityEngine;


public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int startingHealth = 5;
    [SerializeField] private int currentHealth;


    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount, Transform objectHit)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
