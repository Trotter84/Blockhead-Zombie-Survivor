using UnityEngine;


public class Projectile : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject bulletContainer;


//TODO: Get Bullet to end correctly.

    void Start()
    {
        bulletContainer = GameObject.Find("Bullet Container");
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other != null)
        {
            Debug.Log("Hi");
            gameObject.SetActive(false);
            gameObject.transform.parent = bulletContainer.transform;
        }
    }
}
