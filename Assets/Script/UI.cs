using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;
    public TextMeshProUGUI interactionText;
    public TextMeshProUGUI winText;

    void Awake()
    {
        instance = this;
        if(interactionText != null)
        {
            interactionText.text = "";
        }
    }

    public void ShowText(string message)
    {
        if(interactionText != null)
        {
            interactionText.text = message;
        }
    }

    public void HideText()
    {
        if(interactionText != null)
        {
            interactionText.text = "";
        }
    }

    public void ShowWinText()
    {
        if (winText != null)
            winText.gameObject.SetActive(true);
    }

}
