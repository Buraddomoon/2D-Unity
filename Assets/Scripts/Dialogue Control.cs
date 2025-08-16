using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public Text speechtext;
    public Text actornametext;

    [Header("Settings")]
    public int typingspeed;
    private string[] sentences;
    private int index;


    public void speech(Sprite p, string[] txt, string actorname)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actornametext.text = actorname;
        StartCoroutine(TypeSentence());
    }
    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechtext.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
    }
    public void nextsentence()
    {
        if (speechtext.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechtext.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechtext.text = "";
                index = 0;
                dialogueObj.SetActive(false);
            }
        }
    }
}

