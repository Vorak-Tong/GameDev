using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool doorUsed = false;
    private bool lightUsed = false;
    private bool slept = false;

    public TextMeshProUGUI winText;

    void Awake()
    {
        instance = this;
        if (winText != null)
            winText.text = "";
    }

    public void DoorUsed()
    {
        doorUsed = true;
        CheckWin();
    }

    public void LightUsed()
    {
        lightUsed = true;
        CheckWin();
    }

    public void Slept()
    {
        slept = true;
        CheckWin();
    }

    void CheckWin()
    {
        Debug.Log($"CheckWin: Door={doorUsed}, Light={lightUsed}, Sleep={slept}");
        if (doorUsed && lightUsed && slept)
        {
            if (winText != null)
            {
                winText.text = "You Win!";
            }
            Debug.Log("YOU WIN!");
        }
    }
}
