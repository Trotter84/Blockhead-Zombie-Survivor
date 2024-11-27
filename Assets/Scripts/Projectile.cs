using UnityEngine;


public class Projectile : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Weapon weapon;


//TODO: Get Bullet to end correctly.


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
        if (other != null)
        {
            var health = other.transform.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log($"Ray has hit {other.transform}");
                health.TakeDamage(weapon.bulletDamage, other.transform);
                gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
        



        // Debug.Log("Hello");
        // var colliderHit = other.transform.GetComponent<Collider>();
        // if (colliderHit != null)
        // {
        //     Debug.Log("Hi");
        //     gameObject.SetActive(false);
        // }
        
    }
}
