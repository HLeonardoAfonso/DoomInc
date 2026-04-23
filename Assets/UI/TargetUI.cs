using UnityEngine;
using TMPro;

public class TargetUI : MonoBehaviour
{
    public static TargetUI Instance; 
    public TMP_Text targetText;

    private int killCount = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateKillUI();
    }

    public void RegisterKill()
    {
        killCount++;
        UpdateKillUI();
    }

    void UpdateKillUI()
    {
        if (targetText != null) targetText.text = $"Kills: {killCount}";
    }
}