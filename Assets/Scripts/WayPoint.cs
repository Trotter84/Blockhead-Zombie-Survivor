using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject player;
    private float timer;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            transform.position = player.transform.position;
            timer = 0;
        }
    }
}
