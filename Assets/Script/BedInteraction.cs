using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteraction : MonoBehaviour
{
    public Transform player;
    public float interactionDistance = 3.0f;
    private bool isSleeping = false;

    private Renderer bedRenderer;
    private Color originalColor;
    private bool isNearby = false;

    void Start()
    {
        bedRenderer = GetComponent<Renderer>();
        if(bedRenderer != null)
        {
            originalColor = bedRenderer.material.color;
        }
    }

    void Update()
    {
        if (isSleeping) return;
        
        float distance = Vector3.Distance(player.position, transform.position);
        bool nowNearby = distance <= interactionDistance;

        if(nowNearby && !isNearby)
        {
            UI.instance.ShowText("Press 'B' to sleep");
        }
        else if(!nowNearby && isNearby)
        {
            UI.instance.HideText();
        }
        isNearby = nowNearby;

        if (isNearby && Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(SleepRoutine());
        }
    }

    IEnumerator SleepRoutine()
    {
        isSleeping = true;
        UI.instance.ShowText("Sleeping....");

        if (bedRenderer != null)
        {
            bedRenderer.material.color = Color.blue;
        }

        // Simulate sleep for 3s
        yield return new WaitForSeconds(3.0f);

        Debug.Log("Woke up!");
        if (GameManager.instance != null)
            GameManager.instance.Slept();

        if (bedRenderer != null)
        {
            bedRenderer.material.color = originalColor;
        }
        isSleeping = false;

    }
}
