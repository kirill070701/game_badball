using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenu : MonoBehaviour
{
    public void OnClickStart()
    {
        Destroy(GameObject.Find("prefavMenuStart"));
    } 
}
