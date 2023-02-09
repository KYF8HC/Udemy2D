using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]QuestionSO question;
    [SerializeField]GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField]Sprite defaultAnswerSprite;
    [SerializeField]Sprite correctAnswerSprite;

    void Start()
    {
        questionText.text = question.getQuestion();
        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.getAnswerAtIndex(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        if(index == question.getCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            int Correctindex = question.getCorrectAnswerIndex();
            string correctAnswer = question.getAnswerAtIndex(Correctindex);
            questionText.text = "Sorry you were wrong! The correct answer was:\n " + correctAnswer;
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
}
