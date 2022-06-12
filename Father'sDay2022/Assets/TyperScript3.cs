using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TyperScript3 : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    public int Index;
    public string[] Sentences;
    public float TypingSpeed;
    public bool IsShaking = true;
    private Animator Anim;
    private int SceneIndex = 0;

    IEnumerator Type()
    {
        foreach (char Letter in Sentences[Index].ToCharArray())
        {
            TextDisplay.text += Letter;
            yield return new WaitForSeconds(TypingSpeed);
        }

    }

    private void Start()
    {
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextSentence()
    {
        if (Index < Sentences.Length - 1)
        {
            Index++;
            TextDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            TextDisplay.text = "";
        }

    }
}
