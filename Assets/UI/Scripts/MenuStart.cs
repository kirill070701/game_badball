using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour
{
    public static bool buttonStart = false;
    private GameObject prefabJoystick;
    private Position position;
    public void OnCliclStart()
    {
        Destroy(GameObject.Find("prefavMenuStart"));
        position = new Position();
        prefabJoystick = Resources.Load("Prefabs/PrefabJoystic") as GameObject;

        Instantiate(prefabJoystick, prefabJoystick.transform.position, Quaternion.identity);
        position.ConnectionObject();
        print("OK");
        buttonStart = true;
    }
}
