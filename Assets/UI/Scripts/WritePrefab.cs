using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class WritePrefab : MonoBehaviour
{
    public void WriteObject(GameObject gameObject)
    {
        Instantiate(gameObject);
    }
}
