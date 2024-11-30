using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currHealth { get; private set; }
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        currHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage)
    {
        // Ensure health stays within the range of 0 to startingHealth
        currHealth = Mathf.Clamp(currHealth - damage, 0, startingHealth);
        if(currHealth > 0)
        {
            anim.SetTrigger("hurt");    
        }
        else
        {
            anim.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
        }
    
    }
    public void AddHealth(float value)
    {
            currHealth = Mathf.Clamp(currHealth + value, 0, startingHealth);
    }
}