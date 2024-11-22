using UnityEngine;


public class Projectile : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 10.0f;


    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }
}
