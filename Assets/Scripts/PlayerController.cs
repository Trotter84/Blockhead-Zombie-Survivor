using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    // [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject wayPoint;
    [SerializeField] private Camera cameraPosition;
    private int cameraSwap = 1;
    [SerializeField] private GameObject weapon;
    [SerializeField] private Weapon weaponScript;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float turnSpeed = 200f;
  

    void Start()
    {
        cameraPosition = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (cameraPosition == null)
        {
            Debug.LogError("The Camera GameObject on the Player is NULL.");
        }

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
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            switch (cameraSwap)
            {
                case 0:
                    cameraPosition.transform.SetParent(null, true);
                    cameraPosition.transform.position = new Vector3(0, 5f, -4.4000001f);
                    cameraPosition.transform.rotation = Quaternion.Euler(45, 0, 0);
                    cameraSwap++;
                    break;
                case 1:
                    cameraPosition.transform.SetParent(transform, true);
                    cameraPosition.transform.position = transform.position + new Vector3(0.09f, 0.3f, 0);
                    cameraPosition.transform.rotation = transform.rotation;
                    cameraSwap--;
                    break;
            }
        }
    }

}