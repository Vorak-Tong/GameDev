using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveable : MonoBehaviour
{
    private GameObject gameObjectA;
    // Start is called before the first frame update
    void Start()
    {
        gameObjectA = GameObject.Find("CubeObject");

        print(gameObjectA.name);
        print(gameObjectA.tag);
        print(gameObjectA.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObjectA.transform.Translate(1f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObjectA.transform.Translate(-1f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObjectA.transform.Translate(0.0f, 1f, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObjectA.transform.Translate(0.0f, -1f, 0.0f);
        }
    }
}
