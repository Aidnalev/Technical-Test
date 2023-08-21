using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Image healthBarImage; // Asigna aquí la imagen de tipo "Filled" en el Inspector
    [SerializeField] private TextMeshProUGUI healthText; // Asigna aquí el componente TMP en el Inspector
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        float fillAmount = currentHealth / maxHealth;
        healthBarImage.fillAmount = fillAmount;
        healthText.text = $"{currentHealth}/{maxHealth}";
    }
}
