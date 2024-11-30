using System.Collections.Generic;
using UnityEngine;

public class HealthPickups : MonoBehaviour
{
    [SerializeField] private float healthValue;

    // Start is called before the first frame update
    void Start()
    {
        // No specific logic needed for the Start method in this case
    }

    // Update is called once per frame
    void Update()
    {
        // No specific logic needed for the Update method in this case
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false); 
        }
    }
}