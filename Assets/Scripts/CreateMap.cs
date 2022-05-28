using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class CreateMap : MonoBehaviour
{
    private string jsonString;
    private JsonData itemData;
    private string[] infoObjects;
    private int quantityObjects;
    private int[] roomsObjects;
    private string[] lengthObjects;
    private GameObject[] objects;
    private GameObject installationObjects;
    private float locationLength;

    //Поиск объектов
    private void SearchObjects()
    {
        objects = new GameObject[16];
        objects[0] = Resources.Load("1") as GameObject;
        objects[1] = Resources.Load("Boiler") as GameObject;
        objects[2] = Resources.Load("Big Bailer") as GameObject;
        objects[3] = Resources.Load("Islands") as GameObject;
        objects[4] = Resources.Load("Snake") as GameObject;
        objects[5] = Resources.Load("Crack") as GameObject;
        objects[6] = Resources.Load("Tower") as GameObject;
        objects[7] = Resources.Load("Hola1") as GameObject;
        objects[8] = Resources.Load("Hola2") as GameObject;
        objects[9] = Resources.Load("Hola3") as GameObject;
        objects[10] = Resources.Load("Bridges1") as GameObject;
        objects[11] = Resources.Load("Bridges2") as GameObject;
        objects[12] = Resources.Load("Bridges3") as GameObject;
        objects[13] = Resources.Load("Bridges4") as GameObject;
        objects[14] = Resources.Load("Towe2") as GameObject;
        objects[15] = Resources.Load("Finish") as GameObject;
    }

    // чтение JSON файла в котором находятся данные об объектах препядствий
    private string[] ReadJSON()
    {
        jsonString = File.ReadAllText(Application.dataPath + "/Scripts/Objects.json");
        itemData = JsonMapper.ToObject(jsonString);
        lengthObjects = new string[itemData["objects"].Count];
        for (int i = 0; i < itemData["objects"].Count - 1; i++)
        {
            lengthObjects[i] = (itemData["objects"][i]["length"]).ToString();
        }
        lengthObjects[itemData["objects"].Count - 1] = (itemData["objects"][itemData["objects"].Count - 1]["length"]).ToString();
        return lengthObjects;
    }

    //создание случайного порядка объектов препядствий и его длину сцены
    private int[] OlderObject()
    {
        System.Random rnd = new System.Random();
        quantityObjects = rnd.Next(10, 20);
        roomsObjects = new int[quantityObjects];
        for (int i = 0; i < quantityObjects - 1; i++)
        {
            roomsObjects[i] = rnd.Next(0, 15);
        }
        roomsObjects[quantityObjects - 1] = 15;
        return roomsObjects;
    }

    public void ArrangementObjects()
    {
        SearchObjects();
        int[] number = OlderObject();       //порядок
        infoObjects = ReadJSON();           //информация
        locationLength = 5f;
        for (int i = 0; i < number.Length; i++)
        {
            if (i == 0)
            {
                if (number[i] == 2)
                {
                    installationObjects = Instantiate(objects[number[i]], objects[number[i]].transform.position, Quaternion.identity) as GameObject;
                    installationObjects.transform.localPosition = new Vector3(locationLength + (float.Parse(infoObjects[number[i]]) / 2), -0.2f - 4, 0);
                    installationObjects.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                    installationObjects.AddComponent<MeshCollider>();
                    installationObjects.GetComponent<MeshCollider>().enabled = true;
                    locationLength += float.Parse(infoObjects[number[i]]);
                }
                else if (number[i] == 3)
                {
                    installationObjects = Instantiate(objects[number[i]], objects[number[i]].transform.position, Quaternion.identity) as GameObject;
                    installationObjects.transform.localPosition = new Vector3(locationLength + (float.Parse(infoObjects[number[i]]) / 2), -0.2f, 0);
                    installationObjects.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                    installationObjects.AddComponent<MeshCollider>();
                    installationObjects.GetComponent<MeshCollider>().enabled = true;
                    locationLength += float.Parse(infoObjects[number[i]]);
                }
                else
                {
                    installationObjects = Instantiate(objects[number[0]], objects[number[0]].transform.position, Quaternion.identity) as GameObject;
                    installationObjects.transform.localPosition = new Vector3(locationLength + (float.Parse(infoObjects[number[i]]) / 2), -0.2f, 0);
                    installationObjects.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                    installationObjects.AddComponent<MeshCollider>();
                    installationObjects.GetComponent<MeshCollider>().enabled = true;
                    locationLength += float.Parse(infoObjects[number[i]]);
                }
            }
            else
            {
                if (number[i] == 2)
                {
                    installationObjects = Instantiate(objects[number[i]], objects[number[i]].transform.position, Quaternion.identity) as GameObject;
                    installationObjects.transform.localPosition = new Vector3(locationLength + (float.Parse(infoObjects[number[i]]) / 2), -0.2f - 4, 0);
                    installationObjects.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                    installationObjects.AddComponent<MeshCollider>();
                    installationObjects.GetComponent<MeshCollider>().enabled = true;
                    locationLength += float.Parse(infoObjects[number[i]]);
                }
                else if (number[i] == 3)
                {
                    installationObjects = Instantiate(objects[number[i]], objects[number[i]].transform.position, Quaternion.identity) as GameObject;
                    installationObjects.transform.localPosition = new Vector3(locationLength + (float.Parse(infoObjects[number[i]]) / 2), -0.2f, 0);
                    installationObjects.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                    installationObjects.AddComponent<MeshCollider>();
                    installationObjects.GetComponent<MeshCollider>().enabled = true;
                    locationLength += float.Parse(infoObjects[number[i]]);
                }
                else if (number[i] == 15)
                {
                    installationObjects = Instantiate(objects[number[i]], objects[number[i]].transform.position, Quaternion.identity) as GameObject;
                    installationObjects.transform.localPosition = new Vector3(locationLength + (float.Parse(infoObjects[number[i]]) / 2), (float)-0.2, 0);
                    installationObjects.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    installationObjects.AddComponent<MeshCollider>();
                    installationObjects.GetComponent<MeshCollider>().enabled = true;
                    locationLength += float.Parse(infoObjects[number[i]]);
                }
                else
                {
                    installationObjects = Instantiate(objects[number[i]], objects[number[i]].transform.position, Quaternion.identity) as GameObject;
                    installationObjects.transform.localPosition = new Vector3(locationLength + (float.Parse(infoObjects[number[i]]) / 2), (float)-0.2, 0);
                    installationObjects.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                    installationObjects.AddComponent<MeshCollider>();
                    installationObjects.GetComponent<MeshCollider>().enabled = true;
                    locationLength += float.Parse(infoObjects[number[i]]);
                }
            }
        }
    }
}
