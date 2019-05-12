using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionHelper : MonoBehaviour
{
    public Text question;

    [SerializeField]
    private string answer;

    private void Start()
    {
        question.text = "Название места, которое чаще всего взламывают";
        answer = "жопа";
    }

    public string Answer
    {
        get
        {
            return answer;
        }
        set
        {
            answer = value;
        }
    }
}
