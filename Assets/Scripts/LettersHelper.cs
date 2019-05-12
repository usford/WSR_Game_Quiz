using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LettersHelper : MonoBehaviour
{
    public Transform correctWord;
    public GameObject btnPrebaf;

    private Transform[] pnlLetters;

    private void Start()
    {
    }

    public void Click()
    {
        GameObject newButton = Instantiate(btnPrebaf, new Vector3(), Quaternion.identity);
        newButton.transform.SetParent(correctWord);

        Vector3 scale = newButton.transform.localScale;
        scale.x = 1;
        scale.y = 1;
        scale.z = 1;
        newButton.transform.localScale = scale;

        newButton.GetComponentInChildren<Text>().text = GetComponentInChildren<Text>().text;
        newButton.GetComponent<Button>().onClick.AddListener(() => ClickBack());
        newButton.AddComponent<LettersHelper>();
        newButton.GetComponent<LettersHelper>().correctWord = correctWord;
        newButton.name = gameObject.name;
        gameObject.SetActive(false);
    }

    public void ClickBack()
    {
        gameObject.SetActive(true);

        pnlLetters = new Transform[30];
        for (int i = 0; i < correctWord.transform.childCount; i++)
        {
            pnlLetters[i] = correctWord.transform.GetChild(i);
        }

        int counter = 0;

        try
        {
            foreach (Transform btn in pnlLetters)
            {
                if (btn.name == gameObject.name)
                {
                    Destroy(pnlLetters[counter].gameObject);
                }
                counter++;
            }
        }catch(Exception)
        {

        }
    }
}
