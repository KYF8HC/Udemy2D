using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]List<QuestionSO> Questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField]GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Buttons")]
    [SerializeField]Sprite defaultAnswerSprite;
    [SerializeField]Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField]Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;

    public bool isComplete = false;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = Questions.Count;
        progressBar.value = 0;
    }

    void Update()
    {
        
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            if(progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }
            hasAnsweredEarly = false;
            getNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;
        if(index == currentQuestion.getCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            int Correctindex = currentQuestion.getCorrectAnswerIndex();
            string correctAnswer = currentQuestion.getAnswerAtIndex(Correctindex);
            questionText.text = "Sorry you were wrong! The correct answer was:\n " + correctAnswer;
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
    void DisplayQuestion()
    {
        questionText.text = currentQuestion.getQuestion();
        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.getAnswerAtIndex(i);
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
        if(Questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            scoreKeeper.IncrementQuestionSeen();
        }
    }
    void GetRandomQuestion()
    {
        int index = Random.Range(0, Questions.Count);
        currentQuestion = Questions[index];
        if(Questions.Contains(currentQuestion))
            Questions.Remove(currentQuestion);
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
