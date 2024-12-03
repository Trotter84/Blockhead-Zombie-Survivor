using System.Collections;
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
    [SerializeField] private UIManager uiManager;
    
    [Header("Weapon Stats")]
    public int selectedWeapon;
    public float reloadTime;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold, canFire, isReloading = false;
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

        uiManager = GameObject.Find("Reloading_txt").GetComponent<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("The UIManager Script on Weapon is NULL.");
        }

        fpsCam = Camera.main.GetComponent<Camera>();
        if (fpsCam == null)
        {
            Debug.LogError("The Camera on Weapon is NULL.");
        }

        SelectedWeapon(0);
    }

    void Update()
    {
        if (bulletsLeft > 0 && !isReloading)
        {
            canFire = true;
        }

        if (bulletsLeft <= 0 || isReloading)
        {
            canFire = false;
        }
    }

    public void Fire()
    {
        if (canFire)
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

    void SelectedWeapon(int selectedWeapon)
    {
        switch (selectedWeapon)
        {
            case 0:
                allowButtonHold = false;
                magazineSize = 9;
                reloadTime = 1.5f;
                bulletsLeft = magazineSize;
                break;
            case 1:
                allowButtonHold = true;
                magazineSize = 32;
                reloadTime = 2.5f;
                bulletsLeft = magazineSize;
                break;
            case 2:
                allowButtonHold = false;
                magazineSize = 4;
                reloadTime = 4f;
                bulletsLeft = magazineSize;
                break;
        }
    }

    public void Reload()
    {
        if (bulletsLeft != magazineSize)
        {
            isReloading = true;
            StartCoroutine(ReloadRoutine());
        }
    }


    IEnumerator ReloadRoutine()
    {
        StartCoroutine(uiManager.ReloadingUIRoutine(isReloading, reloadTime));
        yield return new WaitForSeconds(reloadTime);
        StopCoroutine(uiManager.ReloadingUIRoutine(isReloading, reloadTime));
        bulletsLeft = magazineSize;
        isReloading = false;
        
    }
}
