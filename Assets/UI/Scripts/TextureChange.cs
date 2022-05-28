using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using TMPro;

public class TextureChange : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    [SerializeField] private Sprite[] imagesTextures;
    [SerializeField] private GameObject menuShop;
    [SerializeField] private GameObject menu;
    private Image imageSpriteTexture;
    private string jsonString;
    private JsonData jsonData;
    private TextMeshProUGUI textNameTexture;
    private TextMeshProUGUI textPriceTexture;
    private int numberTexture = 0;
    private GameObject prefabMenu;
    private GameObject nameTexture;
    private GameObject priceTexture;
    private GameObject spriteTexture;
    private GameObject sphere;

    [SerializeField] private TextMeshProUGUI balls;

    private void Start()
    {
        WriteTypeTexture();
        PriefabStart priefabStart = new PriefabStart();
        balls.GetComponent<TextMeshProUGUI>().text = priefabStart.MenuPoints();
    }

    private void WriteTypeTexture()
    {
        jsonString = File.ReadAllText(Application.dataPath + "/Scripts/TextureSphere.json");
        jsonData = JsonMapper.ToObject(jsonString);

        nameTexture = GameObject.Find("NameTexture");
        priceTexture = GameObject.Find("PriceTexture");
        spriteTexture = GameObject.Find("Texture");
        prefabMenu = GameObject.Find("prefavMenuStart(err)");


        textNameTexture = nameTexture.GetComponent<TextMeshProUGUI>();
        textNameTexture.text = jsonData[1][numberTexture][0].ToString();

        textPriceTexture = priceTexture.GetComponent<TextMeshProUGUI>();
        textPriceTexture.text = "Purchased";

        imageSpriteTexture = spriteTexture.GetComponent<Image>();
        imageSpriteTexture.sprite = imagesTextures[numberTexture];

        DeletePrefab deletePrefab = new DeletePrefab();
        deletePrefab.Delete(prefabMenu);
    }
    public void ChangeTextureForward()
    {
        if (numberTexture < jsonData[1].Count-1)
        {
            numberTexture++;

            textNameTexture = nameTexture.GetComponent<TextMeshProUGUI>();
            textNameTexture.text = jsonData[1][numberTexture][0].ToString();

            textPriceTexture = priceTexture.GetComponent<TextMeshProUGUI>();
            if ((bool)jsonData[2][numberTexture])
            {
                textPriceTexture.text = "Purchased";
            }
            else
            {
                textPriceTexture.text = jsonData[1][numberTexture][1].ToString();
            }

            imageSpriteTexture = spriteTexture.GetComponent<Image>();
            imageSpriteTexture.sprite = imagesTextures[numberTexture];
        }

    }
    public void ChangeTextureBack()
    {
        if (numberTexture > 0)
        {
            numberTexture--;

            textNameTexture = nameTexture.GetComponent<TextMeshProUGUI>();
            textNameTexture.text = jsonData[1][numberTexture][0].ToString();

            textPriceTexture = priceTexture.GetComponent<TextMeshProUGUI>();
            if ((bool)jsonData[2][numberTexture])
            {
                textPriceTexture.text = "Purchased";
            }
            else
            {
                textPriceTexture.text = jsonData[1][numberTexture][1].ToString();
            }

            imageSpriteTexture = spriteTexture.GetComponent<Image>();
            imageSpriteTexture.sprite = imagesTextures[numberTexture];
        }
    }
    public void OnClick()
    {
        SaveDatas();
        new DeletePrefab().Delete(menuShop);
        new WritePrefab().WriteObject(menu);
    }
    private void ChangeMaterial()
    {
        sphere = GameObject.Find("Sphere1");
        sphere.GetComponent<Renderer>().material = materials[numberTexture];
    }
    public void InstallingSavedMaterial()
    {
        sphere = GameObject.Find("Sphere1");
        for (int i = 0; i < int.Parse(jsonData[1].Count.ToString()); i++)
        {
            if (jsonData[0].ToString() == jsonData[1][i][0].ToString())
            {
                sphere.GetComponent<Renderer>().material = materials[i];
                break;
            }
        }
    }
    private void SaveDatas()
    {
        PriefabStart priefabStart = new PriefabStart();
        
        if (jsonData[2][numberTexture].ToString() != "True")
        {
            if (int.Parse(priefabStart.MenuPoints()) >= int.Parse(jsonData[1][numberTexture][1].ToString()))
            {
                jsonData[2][numberTexture] = true;

                ConservationInfo conservationInfo = new ConservationInfo();
                conservationInfo.ConservationDataDeduction(int.Parse(jsonData[1][numberTexture][1].ToString()));

                jsonData[0] = jsonData[1][numberTexture][0].ToString();
                ChangeMaterial();
            }
        }
        else
        {
            jsonData[0] = jsonData[1][numberTexture][0].ToString();
            ChangeMaterial();
        }
        jsonData = JsonMapper.ToJson(jsonData);
        File.WriteAllText(Application.dataPath + "/Scripts/TextureSphere.json", jsonData.ToString());
    }
}
