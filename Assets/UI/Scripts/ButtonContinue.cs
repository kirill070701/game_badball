using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonContinue : MonoBehaviour
{
    private ConservationInfo conservationInfo = new ConservationInfo();
    public void OnCliclStart()
    {
        //conservationInfo = GameObject.Find("Sphere1").GetComponent<ConservationInfo>();
        conservationInfo.ConservationData();
        SceneManager.LoadScene("SampleScene");
    }
}
