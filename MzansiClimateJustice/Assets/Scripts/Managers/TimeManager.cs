using UnityEngine;
using System;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public string currentDateString; // Publicly accessible for UI or debugging

    private DateTime startDate = new DateTime(2026, 1, 1);
    private DateTime endDate = new DateTime(2030, 12, 31);
    private DateTime currentDate;

    private float totalRealTime = 20f * 60f; // 20 minutes in seconds
    private float elapsedRealTime = 0f;

    public TextMeshProUGUI dateText;

    void Start()
    {
        currentDate = startDate;
        UpdateDateString();
    }

    void Update()
    {
        if (currentDate >= endDate) return;

        elapsedRealTime += Time.deltaTime;

        float progress = Mathf.Clamp01(elapsedRealTime / totalRealTime);
        double totalGameDays = (endDate - startDate).TotalDays;
        double daysPassed = progress * totalGameDays;

        currentDate = startDate.AddDays(daysPassed);
        UpdateDateString();
    }

    void UpdateDateString()
    {
        currentDateString = currentDate.ToString("MMMM yyyy"); // e.g., "March 2028"
        dateText.text = currentDateString;
    }
}
