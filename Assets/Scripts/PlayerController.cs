using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject wayPoint;

    [SerializeField] private GameObject zombie;
    
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float turnSpeed = 250f;
  

    private float timer = 0.5f;

    void Start()
    {
        wayPoint = GameObject.Find("WayPoint");
        if (wayPoint == null) 
        {
            Debug.LogError("The WayPoint GameObject on the Player is NULL.");
        }
    }

    void Update()
    {
        Movement();
        zombie = GameObject.Find("Zombie(Clone)");
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += -transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnManager.Death();
        }
    }

}