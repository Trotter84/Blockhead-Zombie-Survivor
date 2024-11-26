using UnityEngine;


public class Weapon : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    
    [Header("Bullet Attributes")]
    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] [Range(1, 10)] private int bulletDamage = 1;

    private RaycastHit hitInfo;


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
        Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.up);

        Debug.DrawRay(bulletSpawnPoint.position, bulletSpawnPoint.up * 25, Color.blue, 3f);
        
        GameObject bullet = SpawnManager.spawnManager.GetPooledBullets();
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = bulletSpawnPoint.rotation;
            bullet.transform.parent = bulletSpawnPoint.transform;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().linearVelocity = bulletSpawnPoint.up * bulletSpeed;
        }

        if (Physics.Raycast(ray, out hitInfo, 25))
        {
            var health = hitInfo.transform.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log($"Ray has hit {hitInfo.transform}");
                health.TakeDamage(bulletDamage, hitInfo.transform);
            }
        }
    }

}
