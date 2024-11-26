using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [Header("Components")]
    public static SpawnManager spawnManager;
    [SerializeField] private Transform bulletSpawnPoint;


    [Header("Spawn Control")]
    [SerializeField] private bool isSpawning = false;

    [Header("Bullet Pool")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int bulletCountToPool = 30;
    [SerializeField] private List<GameObject> pooledBullets = new List<GameObject>();
    [SerializeField] private GameObject bulletContainer;

    [Header("Zombie Pool")]
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private int zombieCountToPool = 10;
    [SerializeField] private List<GameObject> pooledZombies = new List<GameObject>();
    [SerializeField] private GameObject zombieContainer;

    [Header("Zombie Spawn Details")]
    [SerializeField] private float zombieSpawnDelay = 4f;
    

    private void Awake()
    {
        if (spawnManager == null)
        {
            spawnManager = this;
        }

        bulletSpawnPoint = GameObject.Find("BulletSpawnPoint").GetComponent<Transform>();
        if (bulletSpawnPoint == null)
        {
            Debug.LogError("The BulletSpawnPoint GameObject on the Spawn Manager is NULL.");
        }
    }

    void Start()
    {
        InitiatePools();

        isSpawning = GameManager.gameManager.isGameActive;

        StartCoroutine(SpawnZombieRoutine());
    }

    private void InitiatePools()
    {
        for (int i = 0; i < bulletCountToPool; i++)
        {
            GameObject bullets = Instantiate(bulletPrefab);
            bullets.transform.parent = bulletContainer.transform;
            bullets.SetActive(false);
            pooledBullets.Add(bullets);
        }

        for (int i = 0; i < zombieCountToPool; i++)
        {
            GameObject zombies = Instantiate(zombiePrefab);
            zombies.transform.parent = zombieContainer.transform;
            zombies.SetActive(false);
            pooledZombies.Add(zombies);
        }
    }

    public GameObject GetPooledBullets()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        return null;
    }

    public GameObject GetPooledZombies()
    {
        for (int i = 0; i < pooledZombies.Count; i++)
        {
            if (!pooledZombies[i].activeInHierarchy)
            {
                return pooledZombies[i];
            }
        }
        return null;
    }

    IEnumerator SpawnZombieRoutine()
    {
        while (isSpawning)
        {
            GameObject zombie = GetPooledZombies();
            if (zombie != null)
            {
                zombie.transform.position = new Vector3(Random.Range(2f, 5f), 0.5f, Random.Range(-3f, 3f));
                zombie.SetActive(true);
            }
            yield return new WaitForSeconds(zombieSpawnDelay);
        }
    }
}
