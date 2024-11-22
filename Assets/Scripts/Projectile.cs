using UnityEngine;


public class Projectile : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int damage = 1;
    [SerializeField] private float bulletLife = 3;


    void Awake()
    {
        Destroy(gameObject, bulletLife);
    }

    void OnCollisionEnter(Collision other)
    {
        var health = other.transform.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
