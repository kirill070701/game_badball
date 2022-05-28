using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class DeletePrefab : MonoBehaviour
{
    public void Delete(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
