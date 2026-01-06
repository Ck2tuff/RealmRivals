using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Required for Coroutines (for the timer)

public class GameManager : MonoBehaviour
{
    [Header("Match Settings")]
    public float matchDuration = 180f; // 3 minutes
    public float overtimeDuration = 120f; // 2 minutes
    private float timeRemaining;

    [Header("Scoring")]
    private int playerCrowns = 0;
    private int opponentCrowns = 0;

    [Header("UI References")]
    public Text timerText;
    public Text crownScoreText; // e.g., "1 - 0"

    void Start()
    {
        timeRemaining = matchDuration;
        // Start the main timer countdown
        StartCoroutine(TimerCoroutine());
    }
    
    // --- Timer Logic ---

    IEnumerator TimerCoroutine()
    {
        while (timeRemaining > 0)
        {
            yield return null; // Wait one frame
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }

        // Timer hit zero: Check for Sudden Death or Win
        CheckMatchEnd(false);
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            // Format time as M:SS
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
        }
    }

    // --- Crown Scoring ---

    public void AddCrown(bool isPlayerTeam)
    {
        if (isPlayerTeam)
        {
            playerCrowns++;
        }
        else
        {
            opponentCrowns++;
        }
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (crownScoreText != null)
        {
            crownScoreText.text = playerCrowns + " - " + opponentCrowns;
        }
    }

    // --- End Game Logic ---

    public void CheckMatchEnd(bool isKingTowerDestroyed)
    {
        // King Tower destruction is an instant win
        if (isKingTowerDestroyed)
        {
            // The team whose King Tower was NOT destroyed wins
            // (You'll need to pass the winning team ID here in final code)
            Debug.Log("Game Over: Instant King Tower Win!");
            return; 
        }

        // If time runs out (standard match end)
        if (timeRemaining <= 0)
        {
            if (playerCrowns == opponentCrowns)
            {
                // Start Sudden Death
                Debug.Log("SUDDEN DEATH! Next Crown Wins.");
                timeRemaining = overtimeDuration;
                StartCoroutine(TimerCoroutine()); // Restart timer for overtime
            }
            else
            {
                // Standard Crown Win
                StopCoroutine(TimerCoroutine());
                string winner = (playerCrowns > opponentCrowns) ? "Player" : "Opponent";
                Debug.Log("Game Over. Winner based on Crowns: " + winner);
            }
        }
    }
    
    // Optional: Public function to stop the timer from external scripts (like TowerHealth)
    public void EndGameImmediately(bool playerWins)
    {
        StopAllCoroutines();
        string winner = playerWins ? "Player" : "Opponent";
        Debug.Log("Game Ended Immediately. Winner: " + winner);
    }
}
