using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Transform player;
    public float interactionDistance = 3f;
    private Light roomLight;
    private bool isNearby = false;

    void Start()
    {
        roomLight = GetComponentInChildren<Light>();

        if (roomLight == null)
            Debug.LogWarning("No Light found in children of " + gameObject.name);
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        bool nowNearby = distance <= interactionDistance;

        if (nowNearby && !isNearby)
            UI.instance.ShowText("Press L to Toggle Light");
        else if (!nowNearby && isNearby)
            UI.instance.HideText();

        isNearby = nowNearby;

        if (isNearby && Input.GetKeyDown(KeyCode.L))
        {
            if (roomLight != null)
            {
                roomLight.enabled = !roomLight.enabled;
                if (GameManager.instance != null)
                    GameManager.instance.LightUsed();

                UI.instance.ShowText(roomLight.enabled ? "Light ON" : "Light OFF");
                Invoke(nameof(HidePrompt), 1.5f);
            }
        }

    }

    void HidePrompt()
    {
        UI.instance.HideText();
    }
}
