using UnityEngine;


public class Weapon : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject bulletPrefab;


    public void Fire()
    {
        Instantiate(bulletPrefab, transform.position + new Vector3(0, -0.598129f, 0), transform.rotation);
    }
}
