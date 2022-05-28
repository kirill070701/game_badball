using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class PrefabFinish : MonoBehaviour
{
    public GameObject prefabFinish;
    public Text scores;
    public int earnings;
    public Text textEarnings;
    private ConservationInfo conservationInfo = new ConservationInfo();
    private JsonData jsonData;
    public void WritePrefabFinish()
    {
        prefabFinish = Resources.Load("Prefabs/PrefabFinish") as GameObject;
        Instantiate(prefabFinish, prefabFinish.transform.position, Quaternion.identity);
        WriteData();
    }
    private void WriteData()
    {
        scores = GameObject.Find("scores").GetComponent<Text>();
        jsonData = conservationInfo.ReadingJson();
        scores.text = jsonData["sumPoints"].ToString();

        textEarnings = GameObject.Find("Earnings").GetComponent<Text>();
        textEarnings.text = ScoringPoints.summPoints.ToString();
    }
}
