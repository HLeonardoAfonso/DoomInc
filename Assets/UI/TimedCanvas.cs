using UnityEngine;

public class TimedPanel : MonoBehaviour
{
    public int displayDuration = 3;
    public GameObject targetPanel;

    void Start()
    {
        if (targetPanel == null)
            targetPanel = gameObject;

        targetPanel.SetActive(true);
        Invoke(nameof(HidePanel), displayDuration);
    }

    void HidePanel()
    {
        targetPanel.SetActive(false);
    }
}