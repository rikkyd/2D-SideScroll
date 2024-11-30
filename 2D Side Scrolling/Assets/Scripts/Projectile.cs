using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed; // Speed of the projectile
    private float direction; // Direction of the projectile
    private bool hit; // Flag to indicate if the projectile has hit something
    private Animator anim; // Reference to the animator component
    private BoxCollider2D boxCollider; // Reference to the box collider component
    private float projectileLifetime; // Lifetime of the projectile

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // Get the animator component
        boxCollider = GetComponent<BoxCollider2D>(); // Get the box collider component
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return; // If the projectile has hit something, exit the method

        float movementSpeed = speed * Time.deltaTime; // Calculate the movement distance for this frame
        transform.Translate(movementSpeed, 0, 0); // Move the projectile in the specified direction

        projectileLifetime += Time.deltaTime; // Increment the projectile lifetime
        if (projectileLifetime > 5) gameObject.SetActive(false); // Deactivate the projectile
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the projectile hits something
        hit = true;
        boxCollider.enabled = false; // Disable the collider
        anim.SetTrigger("explodes"); // Trigger the "explode" animation
    }

    // Set the direction of the projectile
    public void SetDirection(float projectile_direction)
    {
        projectileLifetime = 0; // Reset the projectile lifetime

        direction = projectile_direction;
        gameObject.SetActive(true); // Activate the projectile
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != projectile_direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}