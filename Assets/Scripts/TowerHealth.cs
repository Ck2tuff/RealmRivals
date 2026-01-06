using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [Header("Tower Stats")]
    public float maxHealth = 2000f; // Base health for Princess Towers
    private float currentHealth;
    
    // Optional: Used to differentiate King Tower from Princess Towers
    public bool isKingTower = false; 

    void Start()
    {
        currentHealth = maxHealth;
        // If this is the King Tower, give it significantly more HP
        if (isKingTower)
        {
            maxHealth *= 2f; // King Tower has double the HP (e.g., 4000)
            currentHealth = maxHealth;
        }
        
        Debug.Log(transform.name + " initialized with " + currentHealth + " HP.");
    }

    // This public function is called by the UnitController when a unit attacks
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(transform.name + " took " + amount + " damage. Remaining HP: " + currentHealth);

        // Optional: Update health bar UI here
        // UpdateHealthBar(currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 1. Visual/Audio Effects
        // Instantiate explosion particles/sound effect
        
        // 2. Logic for Destruction
        if (isKingTower)
        {
            // Game Over: Opponent wins instantly
            Debug.Log("--- KING TOWER DESTROYED! GAME OVER ---");
            // FindObjectOfType<GameManager>().EndGame(true); 
        }
        else
        {
            // Princess Tower Destroyed
            Debug.Log("Princess Tower destroyed! Opponent scores 1 crown.");
            // FindObjectOfType<GameManager>().AddCrown(1);
        }

        // Disable the tower model/collider
        gameObject.SetActive(false);
    }
}
