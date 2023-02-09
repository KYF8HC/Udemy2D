using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)][SerializeField]string Question = "Enter new question text here.";
    [SerializeField]string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    public string getQuestion()
    {
        return Question;
    }    
    public int getcorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }  
    public string getAnswerIndex(int index)
    {
        return answers[index];
    }  
}
