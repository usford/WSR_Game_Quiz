using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timer = 59;

    public float myTimer
    {
        get
        {
            return timer;
        }
        set
        {
            timer = value;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        GetComponent<Text>().text = "0:" + Mathf.Round(timer).ToString();
    }
}
