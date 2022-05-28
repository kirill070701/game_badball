using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPoints : MonoBehaviour
{
    static public int summPoints = 0;
    public void AmountCollected(int points)
    {
        summPoints += points;
    }
}
