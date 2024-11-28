using TMPro;
using UnityEngine;

public class UpdateHealthLevel : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private Health playerHealthScript;


    void Awake()
    {
        playerHealthText = GetComponent<TextMeshProUGUI>();
        if (playerHealthText == null)
        {
            Debug.LogError("UpdateHealthLevel script requires a TextMeshProUGUI component on the same GameObject.");
        }
    }

    void Start()
    {
        playerHealthScript = GameObject.Find("Player").GetComponent<Health>();
        if (playerHealthScript == null)
        {
            Debug.LogError("The Health script on the UpdateHealthLevel is NULL.");
        }

        UpdateHealthDisplay();
    }

    void Update()
    {
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        playerHealthText.text = $"Health: {playerHealthScript.currentHealth}";
    }
}
