﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
   /* public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;

    [SerializeField]
    private Text questionText;

    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
            unansweredQuestions = questions.ToList<Question>();

        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        currentQuestion = unansweredQuestions[0];

        questionText.text = currentQuestion.question;

        unansweredQuestions.RemoveAt(0);
    }*/

    public List<Question> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;

    public void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        ScoringSystem.Correct();
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void inCorrect()
    {
        ScoringSystem.Incorrect();
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerOptionsScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answer[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerOptionsScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        currentQuestion = 0;

        QuestionTxt.text = QnA[currentQuestion].question;
        SetAnswers();



    }


}