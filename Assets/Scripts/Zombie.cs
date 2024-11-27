using UnityEngine;


//TODO: Get Zombies to face player.


public class Zombie : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject wayPoint;
    private Vector3 wayPointPosition;

    [Header("Attributes")]
    [SerializeField] [Range(0.1f, 5f)] private float zombieSpeed = 0.5f;
    [SerializeField] [Range(1f, 10f)] private float detectionDistance = 10.0f;
    [SerializeField] [Range(1, 10)] private int zombieDamage = 1;


    void Start()
    {
        wayPoint = GameObject.Find("WayPoint");
    }

    void Update()
    {
        wayPointPosition = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        Vector3 zombiePosition = transform.position;

        float distanceFromPlayer = Vector3.Distance(wayPointPosition, zombiePosition);

        if (distanceFromPlayer < detectionDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPointPosition, zombieSpeed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision other)
    { 
        if (other.transform.CompareTag("Player"))
        {
            var health = other.transform.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("Collide.");
                health.TakeDamage(zombieDamage, other.transform);
            }
        }
    }

}
