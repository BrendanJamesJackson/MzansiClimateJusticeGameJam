using UnityEngine;
using System;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public string currentDateString; // Publicly accessible for UI or debugging
    public string timeLeftString;

    private DateTime startDate = new DateTime(2026, 1, 1);
    private DateTime endDate = new DateTime(2030, 12, 31);
    private DateTime currentDate;

    private float totalRealTime = 20f * 60f; // 20 minutes in seconds
    private float elapsedRealTime = 0f;

    public TextMeshProUGUI dateText;
    public TextMeshProUGUI timeLeftText;

    public GameManager gameManager;

    void Start()
    {
        currentDate = startDate;
        UpdateDateString();
        UpdateTimeLeftString();
    }

    void Update()
    {
        if (currentDate >= endDate)
        {
            gameManager.EndGame();
            return;
        }
        

        elapsedRealTime += Time.deltaTime;

        float progress = Mathf.Clamp01(elapsedRealTime / totalRealTime);
        double totalGameDays = (endDate - startDate).TotalDays;
        double daysPassed = progress * totalGameDays;

        currentDate = startDate.AddDays(daysPassed);
        UpdateDateString();
        UpdateTimeLeftString();
    }

    void UpdateDateString()
    {
        currentDateString = currentDate.ToString("MMMM yyyy"); // e.g., "March 2028"
        dateText.text = currentDateString;
    }

    void UpdateTimeLeftString()
    {
        float timeLeft = Mathf.Max(0, totalRealTime - elapsedRealTime);
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);

        timeLeftString = $"{minutes:D2}:{seconds:D2}"; // e.g., "13:45"
        if (timeLeftText != null)
        {
            timeLeftText.text = timeLeftString;
        }
    }

}
