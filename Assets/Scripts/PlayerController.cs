using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject wayPoint;
    [SerializeField] private GameObject weapon;
    [SerializeField] private Weapon weaponScript;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject zombie;
    
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float turnSpeed = 250f;

    private int damage = 1;
    private RaycastHit hitInfo;
  

    void Start()
    {
        wayPoint = GameObject.Find("WayPoint");
        if (wayPoint == null) 
        {
            Debug.LogError("The WayPoint GameObject on the Player is NULL.");
        }

        weapon = GameObject.Find("Weapon");
        if (weapon == null)
        {
            Debug.LogError("The Weapon GameObject on the Player is NULL.");
        }
        weaponScript = weapon.GetComponent<Weapon>();
        if (weaponScript == null)
        {
            Debug.LogError("The WeaponScript on Player is NULL.");
        }
    }

    void Update()
    {
        Movement();
        zombie = GameObject.Find("Zombie(Clone)");
    }

    void Shoot()
    {
        // Debug.Log(weapon.transform.localPosition + " " + weapon.transform.position);
        
        Debug.DrawRay(weapon.transform.localPosition + new Vector3(0, 0, 0.25f), weapon.transform.forward * 25, Color.blue, 3f);
        // Ray ray = new Ray(weapon.transform.position + new Vector3(0, 0.598129f, 1), weapon.transform.forward);

        // if (Physics.Raycast(ray, out hitInfo, 25))
        // {
        //     var health = hitInfo.transform.GetComponent<Health>();
        //     if (health != null)
        //     {
        //         health.TakeDamage(damage);
        //     }
        // }
        // Debug.Log(hitInfo.transform);
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
            weaponScript.Fire();
            // Shoot();
        }
    }

}