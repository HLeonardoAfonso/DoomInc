using UnityEngine;
using UnityEngine.InputSystem;

public class ToolSwitcher : MonoBehaviour
{
    public GameObject[] tools;
    int currentIndex = 0;

    void Start()
    {
        EquipTool(0);
    }

    void Update()
    {
        float scroll = Mouse.current.scroll.ReadValue().y;

        if (scroll > 0f) SwitchTool(1);
        if (scroll < 0f) SwitchTool(-1);
    }

    void SwitchTool(int direction)
    {
        tools[currentIndex].SetActive(false);

        currentIndex = (currentIndex + direction + tools.Length) % tools.Length;
        // The % tools.Length wraps around: going past the last tool loops back to index 0
        // The + tools.Length prevents negative modulo issues when scrolling backwards

        tools[currentIndex].SetActive(true);
    }

    void EquipTool(int index)
    {
        for (int i = 0; i < tools.Length; i++)
            tools[i].SetActive(i == index);

        currentIndex = index;
    }
}
