using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TyperScript : MonoBehaviour
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
        foreach(char Letter in Sentences[Index].ToCharArray())
        {
            TextDisplay.text += Letter;
            yield return new WaitForSeconds(TypingSpeed);
        }
        
    }

    IEnumerator StopShaking()
    {
        yield return new WaitForSeconds(0.5f);
        IsShaking = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Anim = GameObject.FindGameObjectWithTag("Typer").GetComponent<Animator>();
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextSentence()
    {
        if(Index < Sentences.Length - 1)
        {
            Index++;
            TextDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            TextDisplay.text = "";
        }

        if(Index >= 9)
        {
            SceneManager.LoadScene(SceneIndex + 1);
        }
    }

}
