using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsHelper : MonoBehaviour
{
    public GameObject panelCW;
    public GameObject panelQuestion;
    public GameObject panelLetters;
    public GameObject Timer;

    private Transform[] panelCWChild;
    private Transform[] panelLettersChild;

    private string answerUser;
    private string answer;


    private void Start()
    {
        answer = panelQuestion.GetComponent<QuestionHelper>().Answer;
    }

    /// <summary>
    /// Открыть слово
    /// </summary>
    public void OpenWord()
    {
        answerUser = "";
        for (int i = 0; i < panelCW.transform.childCount; i++)
        {
            panelCWChild = new Transform[i + 1];
            panelCWChild[i] = panelCW.transform.GetChild(i);
            answerUser += panelCWChild[i].GetComponentInChildren<Text>().text;
        }

        if (answerUser == panelQuestion.GetComponent<QuestionHelper>().Answer)
        {
            Debug.Log("Вы победили!");
        }
        else
        {
            Debug.Log("Неверное слово!");
        }
    }

    /// <summary>
    /// Дополнительно время
    /// </summary>
    public void AdditionalTime()
    {
        Timer.GetComponent<Timer>().myTimer += 60;
    }

    /// <summary>
    /// Убрать лишние буквы
    /// </summary>
    public void ExtraLetters()
    {
        panelLettersChild = new Transform[30];
        for (int i = 0; i < panelLetters.transform.childCount; i++)
        {          
            panelLettersChild[i] = panelLetters.transform.GetChild(i);
        }

        for (int i = 0; i < panelCW.transform.childCount; i++)
        {
            panelCWChild = new Transform[i + 1];
        }

        for (int i = 0; i < panelCW.transform.childCount; i++)
        {
            panelCWChild[i] = panelCW.transform.GetChild(i);
        }

        //Проверка для букв в поле ввода
        for (int i = 0; i < panelCWChild.Length; i++)
        {
            int counter = 0;

            for (int j = 0; j < answer.Length; j++)
            {
                if (panelCWChild[i].GetComponentInChildren<Text>().text == answer[j].ToString())
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                Destroy(panelCWChild[i].gameObject);
            }
        }

        //Проверка для букв на панели
        for (int i = 0; i < panelLettersChild.Length; i++)
        {
            int counter = 0;

            for (int j = 0; j < answer.Length; j++)
            {
                if (panelLettersChild[i].GetComponentInChildren<Text>().text == answer[j].ToString())
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                Destroy(panelLettersChild[i].gameObject);
            }
        }
    }

    /// <summary>
    /// Открыть случайную букву
    /// </summary>
    public void RandomLetter()
    {

    }
}
