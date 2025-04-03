using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    GameObject Orientation;
    GameObject Player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform LocalOrientation = gameObject.transform.GetChild(i);
            if (LocalOrientation.name == "Orientation")
            {
                Orientation = LocalOrientation.gameObject;
            }
        }
        Player = gameObject.GetComponent<GameObject>();
    }
    void Update()
    {
        
    }
}
