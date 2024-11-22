using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("Components")]
    private SpawnManager spawnManager;

    [Header("Game Control")]
    public bool isGameActive = false;


    void Awake()
    {
        isGameActive = true;
    }

    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

    }

    void Update()
    {

    }
}
