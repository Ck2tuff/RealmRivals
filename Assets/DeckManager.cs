using UnityEngine;
using UnityEngine.UI; 

public class DeckManager : MonoBehaviour
{
    [Header("Elixir Settings")]
    public float maxElixir = 10f;
    public float elixirPerSecond = 0.35f; 
    private float currentElixir = 5f; 

    [Header("UI References")]
    public Text elixirText; 

    [Header("Unit Prefabs")]
    public GameObject knightPrefab;
    public Transform spawnPoint; 

    void Start()
    {
        UpdateElixirUI();
    }

    void Update()
    {
        if (currentElixir < maxElixir)
        {
            currentElixir += elixirPerSecond * Time.deltaTime;
            currentElixir = Mathf.Min(currentElixir, maxElixir); 
            UpdateElixirUI();
        }
    }

    void UpdateElixirUI()
    {
        if (elixirText != null)
        {
            elixirText.text = Mathf.Floor(currentElixir).ToString() + " / " + maxElixir.ToString();
        }
    }

    public void PlayCard(int cardCost, GameObject unitPrefab)
    {
        if (currentElixir >= cardCost)
        {
            // 1. Deduct Elixir
            currentElixir -= cardCost;
            UpdateElixirUI();

            // 2. Spawn the Unit (Instantiate the Prefab)
            Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);

            // Debug feedback
            Debug.Log("Unit spawned! Elixir remaining: " + currentElixir);
        }
        else
        {
            Debug.Log("Not enough Elixir! Cost: " + cardCost + ", Current: " + Mathf.Floor(currentElixir));
        }
    }

    public void PlayKnight()
    {
        // Example unit spawn
        PlayCard(3, knightPrefab);
    }
}
