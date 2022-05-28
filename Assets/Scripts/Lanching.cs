using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;

public class Lanching : MonoBehaviour
{
    private CreateMap createMap = new CreateMap();
    private PriefabStart priefabStart = new PriefabStart();
    private Position position = new Position();
    private ConservationInfo conservationInfo = new ConservationInfo();
    private TextureChange textureChange = new TextureChange();

    GameObject sphere;
    JsonData jsonData;
    string jsonString;
    [SerializeField] private Material [] materials;

    void Start()
    {
        createMap.ArrangementObjects();

        sphere = GameObject.Find("Sphere1");
        jsonString = File.ReadAllText(Application.dataPath + "/Scripts/TextureSphere.json");
        jsonData = JsonMapper.ToObject(jsonString);
        for (int i = 0; i < int.Parse(jsonData[1].Count.ToString()); i++)
        {
            if (jsonData[0].ToString() == jsonData[1][i][0].ToString())
            {
                sphere.GetComponent<Renderer>().material = materials[i];
                break;
            }
        }
        //priefabStart.Menu();
    }
    void Update()
    {
        if (MenuStart.buttonStart == true)
        {
            position.PositionObject();
        }
        if (transform.position.y <= -0.7)
        {
            MenuStart.buttonStart = false;
            conservationInfo.ConservationDataLoss();
            SceneManager.LoadScene("SampleScene");
        }
    }
}
