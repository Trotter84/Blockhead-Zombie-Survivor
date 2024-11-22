using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [Header("Components")]
    public static SpawnManager spawnManager;
    private GameManager gameManager;

    [Header("Object Pool")]
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private List<GameObject> pooledZombieObjects = new List<GameObject>();
    [SerializeField] private int amountToPool = 10;
    private Transform zombieContainer;

    [Header("Spawn Control")]
    [SerializeField] private bool isSpawning = false;

    [Header("Zombie Spawn Details")]
    [SerializeField] private float zombieSpawnDelay = 4f;
    

    private void Awake()
    {
        if (spawnManager == null)
        {
            spawnManager = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject zombies = Instantiate(zombiePrefab);
            zombies.SetActive(false);
            pooledZombieObjects.Add(zombies);
        }

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        isSpawning = gameManager.isGameActive;

        StartCoroutine(SpawnZombieRoutine());
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledZombieObjects.Count; i++)
        {
            if (!pooledZombieObjects[i].activeInHierarchy)
            {
                return pooledZombieObjects[i];
            }
        }
        return null;
    }

    IEnumerator ZombieDeathRoutine(int hitZombie)
    {
        GameObject zombie = GetPooledObject(1);
        if (zombie != null)
        {
            zombie.SetActive(false);
        }
    }

    IEnumerator SpawnZombieRoutine()
    {
        while (isSpawning)
        {
            GameObject zombie = GetPooledObject();
            if (zombie != null)
            {
                zombie.transform.SetParent(zombieContainer, true);
                zombie.transform.position = new Vector3(Random.Range(2f, 5f), 0.5f, Random.Range(-3f, 3f));
                zombie.SetActive(true);
            }
            yield return new WaitForSeconds(zombieSpawnDelay);
        }
    }
}
