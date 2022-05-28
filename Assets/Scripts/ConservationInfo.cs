using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ConservationInfo : MonoBehaviour
{
    private string jsonString;
    private JsonData itemData;
    private JsonData changedData;
    private Info player;
    public ScoringPoints scoringPoints;
    public JsonData ReadingJson()
    {
        jsonString = File.ReadAllText(Application.dataPath + "/Scripts/information.json");
        return JsonMapper.ToObject(jsonString);
    }
    public void ConservationData()
    {
        itemData = ReadingJson();
        player = new Info((int)itemData[0] + 1, (int)itemData[1] + ScoringPoints.summPoints, (int)itemData[2]);
        changedData = JsonMapper.ToJson(player);
        File.WriteAllText(Application.dataPath + "/Scripts/information.json", changedData.ToString());
    }
    public void ConservationDataDeduction(int deduction)
    {
        itemData = ReadingJson();
        player = new Info((int)itemData[0] + 1, (int)itemData[1] - deduction, (int)itemData[2]);
        changedData = JsonMapper.ToJson(player);
        File.WriteAllText(Application.dataPath + "/Scripts/information.json", changedData.ToString());
    }
    public void ConservationDataLoss()
    {
        itemData = ReadingJson();
        player = new Info((int)itemData[0], (int)itemData[1], (int)itemData[2] + 1);
        changedData = JsonMapper.ToJson(player);
        File.WriteAllText(Application.dataPath + "/Scripts/information.json", changedData.ToString());
    }
}
public class Info
{
    public int levelCompleted;
    public int sumPoints;
    public int sumLosses;
    public Info(int levelCompleted, int sumPoints, int sumLosses)
    {
        this.levelCompleted = levelCompleted;
        this.sumPoints = sumPoints;
        this.sumLosses = sumLosses;
    }
}
