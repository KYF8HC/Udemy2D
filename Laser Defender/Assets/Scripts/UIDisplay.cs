using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]Health playerHealth;
    [SerializeField]Slider slider;

    [Header("Score")]
    [SerializeField]TextMeshProUGUI textMeshPro;
    ScoreKeeper scoreKeeper;

    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Update()
    {
        textMeshPro.text = scoreKeeper.GetcurrentScore().ToString("00000000");
        slider.value = playerHealth.GetHealth();
    }
}
