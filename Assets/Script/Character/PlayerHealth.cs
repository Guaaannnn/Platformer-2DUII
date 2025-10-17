using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Slider tHealthSlider;
    private float health = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Hit Enemy");
            health -= 20;

            CheckHealth();
            UpdateSliderUI();
        }
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    private void UpdateSliderUI()
    {
        tHealthSlider.value = health;
    }

}
