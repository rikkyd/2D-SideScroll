using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        // Set the fill amount of the total health bar to the player's current health divided by 10.
        totalHealthBar.fillAmount = playerHealth.currHealth / 10;
        Debug.Log(playerHealth.currHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Set the fill amount of the current health bar to the player's current health divided by 10.
        currHealthBar.fillAmount = playerHealth.currHealth / 10;
    }
}