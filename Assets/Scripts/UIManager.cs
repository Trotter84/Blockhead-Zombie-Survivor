using TMPro;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI reloadingText;

    private float timer;


    void Start()
    {
        reloadingText = GetComponent<TextMeshProUGUI>();
        if (reloadingText == null)
        {
            Debug.LogError("The Reloading_txt TextMeshPro on the UIManager is NULL.");
        }
        
        reloadingText.color = Color.clear;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    // public void WhileReloading()
    // {
    //     if (isReloading)
    //     {
    //         StartCoroutine(ReloadingTextRoutine());
    //     }
    // }

//TODO: Get Reloading UI working.

    public IEnumerator ReloadingUIRoutine(bool isReloading, float reloadTime)
    {
        timer = 0;

        while (isReloading && timer <= reloadTime)
        {
            reloadingText.color = Color.white;
            reloadingText.text = "Reloading";
            yield return new WaitForSeconds(0.25f);
            reloadingText.text = "Reloading.";
            yield return new WaitForSeconds(0.25f);
            reloadingText.text = "Reloading..";
            yield return new WaitForSeconds(0.25f);
            reloadingText.text = "Reloading...";
            yield return new WaitForSeconds(0.25f);
            reloadingText.color = Color.clear;

            // reloadingText.color = Color.white;
            // yield return new WaitForSeconds(0.5f);
            // reloadingText.color = Color.clear;
            // yield return new WaitForSeconds(0.5f);
        }
    }
}
