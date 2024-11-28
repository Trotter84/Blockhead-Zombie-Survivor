using TMPro;
using UnityEngine;

public class UpdateAmmoCount : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private TextMeshProUGUI playerAmmoText;
    [SerializeField] private Weapon weaponScript;


    void Awake()
    {
        playerAmmoText = GetComponent<TextMeshProUGUI>();
        if (playerAmmoText == null)
        {
            Debug.LogError("UpdateHealthLevel script requires a TextMeshProUGUI component on the same GameObject.");
        }
    }

    void Start()
    {
        weaponScript = GameObject.Find("Weapon").GetComponent<Weapon>();
        if (weaponScript == null)
        {
            Debug.LogError("The Weapon script on the UpdateAmmoCount is NULL.");
        }

        UpdateHealthDisplay();
    }

    void Update()
    {
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        playerAmmoText.text = $"Ammo: {weaponScript.bulletsLeft}/{weaponScript.magazineSize}";
    }
}
