using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    private EnemyHealthManager healthManager;

    void Start()
    {
        healthManager = FindObjectOfType<EnemyHealthManager>();
        if (healthManager != null && slider != null)
        {
            slider.maxValue = healthManager.TotalEnemyHealth; // Use property
            slider.value = healthManager.TotalEnemyHealth;    // Use property
        }
    }

    public void UpdateHealth(int health)
    {
        if (slider != null)
        {
            slider.value = health;
        }
    }
}