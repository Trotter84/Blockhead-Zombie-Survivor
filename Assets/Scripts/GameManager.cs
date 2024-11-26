using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("Components")]
    public static GameManager gameManager;
    private SpawnManager spawnManager;

    [Header("Game Control")]
    public bool isGameActive = false;
    [SerializeField] [Range(0.01f, 1f)] private float time = 1f;


    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        isGameActive = true;
    }

    void Update()
    {
        Time.timeScale = time;
    }

}
