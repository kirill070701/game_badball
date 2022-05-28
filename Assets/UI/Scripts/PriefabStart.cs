using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class PriefabStart : MonoBehaviour
{
    public Text scores;
    private JsonData jsonData;
    public ConservationInfo conservationInfo;

    public void Menu()
    {
        scores = GameObject.Find("scores").GetComponent<Text>();
        conservationInfo = new ConservationInfo();
        jsonData = conservationInfo.ReadingJson();
        scores.text = jsonData["sumPoints"].ToString();
    }
    public string MenuPoints()
    {
        conservationInfo = new ConservationInfo();
        jsonData = conservationInfo.ReadingJson();
        return jsonData["sumPoints"].ToString();
    }
}
