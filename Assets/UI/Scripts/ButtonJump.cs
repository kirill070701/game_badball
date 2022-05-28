using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonJump : MonoBehaviour, IPointerClickHandler
{
    public static bool isPreset = false;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        isPreset = true;
    }
}
