using UnityEngine;
using UnityEngine.Rendering;


//TODO: Setup can shoot
//TODO: Add different weapons.


public class Weapon : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Camera fpsCam;
    public bool isFpsActive = false;
    
    [Header("Weapon Stats")]
    public int weaponSelected;
    public float reloadTime;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold, canFire;
    public int bulletsLeft, bulletsShot;

    [Header("Bullet Attributes")]
    [SerializeField] private float shootForce = 30f;
    [Range(1, 10)] public int bulletDamage = 1;

    public RaycastHit hitInfo;
    private Vector3 targetPoint;


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

        fpsCam = Camera.main.GetComponent<Camera>();
        if (fpsCam == null)
        {
            Debug.LogError("The Camera on Weapon is NULL.");
        }

        CheckMagazine(0);
    }

    public void Fire()
    {
        if (!isFpsActive)
        {
            Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.up);
            ShootBullet(ray);
        }
        else
        {
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            ShootBullet(ray);
        }

        bulletsLeft--;

        if (bulletsLeft >= 0)
        {

        }
    }

    private void ShootBullet(Ray ray)
    {
        if (Physics.Raycast(ray, out hitInfo))
        {
            targetPoint = hitInfo.point;
        }
        else
        {
            targetPoint = ray.GetPoint(25);
        }

        Vector3 direction = targetPoint - bulletSpawnPoint.position;
        
        GameObject currentBullet = SpawnManager.spawnManager.GetPooledBullets();

        if (currentBullet != null)
        {
            currentBullet.transform.position = bulletSpawnPoint.position;
            currentBullet.transform.rotation = bulletSpawnPoint.rotation;
            currentBullet.transform.up = direction.normalized;
            currentBullet.SetActive(true);
            // currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
            
            currentBullet.GetComponent<Rigidbody>().linearVelocity = direction.normalized * shootForce;
        }
    }

    void CheckMagazine(int weaponSelected)
    {

        switch (weaponSelected)
        {
            case 0:
                allowButtonHold = false;
                magazineSize = 9;
                bulletsLeft = magazineSize;
                break;
            case 1:
                allowButtonHold = true;
                magazineSize = 32;
                bulletsLeft = magazineSize;
                break;
            case 2:
                allowButtonHold = false;
                magazineSize = 4;
                bulletsLeft = magazineSize;
                break;
        }
    }
}
