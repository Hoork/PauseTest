using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class GameplayUiController : MonoBehaviour
{
    public TextMeshProUGUI PositionLabel;

    public Vector2 Position
    {
        set
        {
            PositionLabel.text = $"Position: {value}";
        }
    }

    private void Start()
    {
        Assert.IsNotNull(PositionLabel);
    }
}
