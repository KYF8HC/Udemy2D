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
        getNextQuestion();
        //DisplayQuestion();
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
        SetButtonState(false);
    }

    void DisplayQuestion()
    {
        questionText.text = question.getQuestion();
        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.getAnswerAtIndex(i);
        }
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void getNextQuestion()
    {
        SetDefaultButtonSprites();
        SetButtonState(true);
        DisplayQuestion();
    }
    void SetDefaultButtonSprites()
    {
        //int index = question.getCorrectAnswerIndex();
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }   
    }
}
