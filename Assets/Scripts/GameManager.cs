using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("Элементы")]
    public Image questionImage;
    public Text[] answersTexts;
    public Button[] answerButtons;

    [Header("Вопрос")]
    public int lives =3;
    //public Question[] questions;    //Length
    public List<Question> questions;   //Count

    public int correctAnswers;
    private int currentQuestionIndex;



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        questions = questions.OrderBy(x => Guid.NewGuid()).ToList();
        currentQuestionIndex = 0;

        UpdateQuestionInfo();
    }

 
    public void CheckAnswer(int playerAnswer)
    {
        if (playerAnswer == questions[currentQuestionIndex].correctAnswer)
        {
            //правильные ответы
            correctAnswers ++;
        }
        else
        {
            lives--;
        }
        currentQuestionIndex ++;

        int maxIndex = questions.Count - 1;
        if (currentQuestionIndex > maxIndex || lives == 0)
        {
            SceneManager.LoadScene(2);
            return;
        }
            UpdateQuestionInfo();
    }

    public void FiftyFifty()
    {
        int correctAnswer = questions[currentQuestionIndex].correctAnswer;
        int disableButtons = 0;

        for(int i = 0; i < answerButtons.Length; i++)
        {
            if (correctAnswer != i)
            {
                answerButtons[i].gameObject.SetActive(false);
                disableButtons++;
                if (disableButtons >= 2)    //0 = answerButtons.Length / 2
                {
                    return;
                }
            }
        }

        //if (correctAnswer != 0)
        //{
        //    answerButtons[0].gameObject.SetActive(false);
        //    disableButtons++;
        //    if (disableButtons >= 2)
        //    {
        //        return;
        //    }
        //}
        //if (correctAnswer != 1)
        //{
        //    answerButtons[1].gameObject.SetActive(false);
        //    disableButtons++;
        //    if (disableButtons >= 2)
        //    {
        //        return;
        //    }
        //}
        //if (correctAnswer != 2)
        //{
        //    answerButtons[2].gameObject.SetActive(false);
        //    disableButtons++;
        //    if (disableButtons >= 2)
        //    {
        //        return;
        //    }
        //}
        //if (correctAnswer != 3)
        //{
        //    answerButtons[3].gameObject.SetActive(false);
        //    disableButtons++;
        //    if (disableButtons >= 2)
        //    {
        //        return;
        //    }
        //}
    }

    private void UpdateQuestionInfo()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(true);
        }
        //answerButtons[0].gameObject.SetActive(true);
        //answerButtons[1].gameObject.SetActive(true);
        //answerButtons[2].gameObject.SetActive(true);
        //answerButtons[3].gameObject.SetActive(true);
        questionImage.sprite = questions[currentQuestionIndex].image;

        for (int i = 0; i < answersTexts.Length; i++)
        {
            answersTexts[i].text = questions[currentQuestionIndex].answer[i];
        }

        //answersTexts[0].text = questions[currentQuestionIndex].answer[0];
        //answersTexts[1].text = questions[currentQuestionIndex].answer[1];
        //answersTexts[2].text = questions[currentQuestionIndex].answer[2];
        //answersTexts[3].text = questions[currentQuestionIndex].answer[3];
    }
}
