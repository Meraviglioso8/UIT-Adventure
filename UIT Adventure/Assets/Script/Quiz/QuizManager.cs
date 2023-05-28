using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TMP_Text QuestionTxt;

    public int WrongAns = 0;

    void Start()
    {
        genarateQuestion();
    }

    void EndGame()
    {
        if (WrongAns == 0)
            SceneManager.LoadScene("EndGame");
        else 
            SceneManager.LoadScene("EndGame1");
    }

    public void Correct()
    {
        QnA.RemoveAt(currentQuestion);
        genarateQuestion();
    }

    public void Wrong()
    {
        WrongAns++;
        QnA.RemoveAt(currentQuestion);
        genarateQuestion();
    }

    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answer[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void genarateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of questions");
            EndGame();
        }   
    }

    
}
