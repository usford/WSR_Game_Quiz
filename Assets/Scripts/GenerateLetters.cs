using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateLetters : MonoBehaviour
{
    public Transform panelLetters;

    private Transform[] pnlLetters;

    public GameObject pnlQuestion;

    private string wordsRU = "абвгдеёжзиёклмнопрстуфхцчшщъыьэюя";
    private string answer;

    private void Start()
    {
        answer = pnlQuestion.GetComponent<QuestionHelper>().Answer;
        pnlLetters = new Transform[30];


        for (int i = 0; i < panelLetters.transform.childCount; i++)
        {
            pnlLetters[i] = panelLetters.transform.GetChild(i);
        }

        int[] randomLetters = new int[100]; //Места для правильных букв

        //Места, где будут правильные буквы
        for (int i = 0; i < answer.Length; i++)
        {
            int random = Random.Range(0, 30);
            int counter = 0;

            for (int j = 0; j < randomLetters.Length; j++)
            {
                if (random == randomLetters[j])
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                randomLetters[i] = random;
            }
            else
            {
                i--;
            }
        }

        //for (int i = 0; i < answer.Length; i++)
        //{
        //    Debug.Log(randomLetters[i]);
        //}

        //for (int i = 0; i < pnlLetters.Length; i++)
        //{
        //    int random = Random.Range(0, wordsRU.Length);
        //    pnlLetters[i].GetComponentInChildren<Text>().text = wordsRU[random].ToString();
        //}

        //Заполнение ячеек правильными буквами
        for (int i = 0; i < pnlLetters.Length; i++)
        {
            for (int j = 0; j < answer.Length; j++)
            {
                if (i == randomLetters[j])
                {
                    int random = Random.Range(0, answer.Length);
                    int counter = 0;

                    for (int c = 0; c < pnlLetters.Length; c++)
                    {
                        if (pnlLetters[c].GetComponentInChildren<Text>().text == answer[random].ToString())
                        {
                            counter++;
                        }
                    }

                    if (counter == 0)
                    {
                        pnlLetters[i].GetComponentInChildren<Text>().text = answer[random].ToString();
                    }
                    else
                    {
                        j--;
                    }

                }
            }
        }
    }

}
