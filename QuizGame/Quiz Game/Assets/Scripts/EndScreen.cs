using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;

    void Start() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
}
