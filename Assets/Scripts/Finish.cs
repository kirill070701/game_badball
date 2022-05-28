using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private Position position = new Position();
    private ScoringPoints scoringPoints = new ScoringPoints();
    private PrefabFinish prefabFinish = new PrefabFinish();
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Finish")
        {
            Position.vector = 0f;
            Position.sensitivity = 0f;
            scoringPoints.AmountCollected(1);
            prefabFinish.WritePrefabFinish();
            Destroy(GameObject.Find("PrefabJoystic(Clone)"));
        }
    }
}
