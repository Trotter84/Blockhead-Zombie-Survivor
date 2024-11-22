using UnityEngine;


public class Weapon : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    
    [Header("Bullet Attributes")]
    [SerializeField] private float bulletSpeed = 10f;


    void Start()
    {
        bulletSpawnPoint = GameObject.Find("BulletSpawnPoint").GetComponent<Transform>();
        if (bulletSpawnPoint == null)
        {
            Debug.LogError("The BulletSpawnPoint Transform on Weapon is NULL.");
        }

        if (bulletPrefab == null)
        {
            Debug.LogError("The Bullet Prefab on Weapon is NULL.");
        }
    }

    public void Fire()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = bulletSpawnPoint.forward * bulletSpeed;
    }
}
