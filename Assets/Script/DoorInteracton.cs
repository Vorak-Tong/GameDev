using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Transform player;
    public float interactionDistance = 3f;
    private bool isOpen = false;
    private bool isNearby = false;
    public float openAngle = 90f;
    public float speed = 2f;

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        bool nowNearby = distance <= interactionDistance;

        if (nowNearby && !isNearby)
            UI.instance.ShowText("Press E to Open/Close Door");
        else if (!nowNearby && isNearby)
            UI.instance.HideText();

        isNearby = nowNearby;

        if (isNearby && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;

            if (GameManager.instance != null)
            {
                GameManager.instance.DoorUsed();
            }
        }

        Quaternion targetRotation = isOpen ?
            Quaternion.Euler(0, openAngle, 0) :
            Quaternion.Euler(0, 0, 0);

        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            targetRotation,
            Time.deltaTime * speed
        );
    }
}
