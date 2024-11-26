using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("Components")]
    public static GameManager gameManager;
    private SpawnManager spawnManager;

    [Header("Game Control")]
    public bool isGameActive = false;


    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        isGameActive = true;
    }

}
