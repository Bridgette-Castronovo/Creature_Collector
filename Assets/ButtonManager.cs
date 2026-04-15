using UnityEngine;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    public Button[] buttons;

    public Color normalColor = Color.white;
    public Color selectedColor = Color.gray;

    private Button currentSelected;

    public void SelectButton(Button clickedButton)
    {
        // Reset previous
        if (currentSelected != null)
        {
            SetButtonColor(currentSelected, normalColor);
        }

        // Set new
        currentSelected = clickedButton;
        SetButtonColor(currentSelected, selectedColor);
    }

    void SetButtonColor(Button button, Color color)
    {
        var colors = button.colors;
        colors.normalColor = color;
        button.colors = colors;

        // Force update immediately
        button.targetGraphic.color = color;
    }
}