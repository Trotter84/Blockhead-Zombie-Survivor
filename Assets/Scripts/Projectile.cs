using UnityEngine;


public class Projectile : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Weapon weapon;


    void Start()
    {
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        if (weapon == null)
        {
            Debug.LogError("The Weapon GameObject on Projectile is NULL.");
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        var health = other.transform.GetComponent<Health>();
        if (health != null)
        {
            Debug.Log($"Ray has hit {other.transform}");
            health.TakeDamage(weapon.bulletDamage, other.transform);
            gameObject.SetActive(false);
        }
        else if (other.collider != null && health == null)
        {
            gameObject.SetActive(false);
        }
    }
}
