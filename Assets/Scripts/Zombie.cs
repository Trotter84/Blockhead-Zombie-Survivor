using Unity.VisualScripting;
using UnityEngine;


public class Zombie : MonoBehaviour
{
    [Header("Components")]
    private GameObject wayPoint;
    private Vector3 wayPointPosition;

    [Header("Attributes")]
    [SerializeField] [Range(0.1f, 5f)] private float zombieSpeed = 0.5f;
    [SerializeField] [Range(1f, 10f)] private float detectionDistance = 10.0f;
    [SerializeField] [Range(1, 10)] private int damage = 1;


    

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

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collide.");
            var health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
