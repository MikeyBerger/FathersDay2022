using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TyperScript2 : MonoBehaviour
{

    public TextMeshProUGUI TextDisplay;
    public int Index;
    public string[] Sentences;
    public float TypingSpeed;
    public bool IsShaking = true;
    private Animator Anim;
    private int SceneIndex = 1;

    IEnumerator Type()
    {
        foreach (char Letter in Sentences[Index].ToCharArray())
        {
            TextDisplay.text += Letter;
            yield return new WaitForSeconds(TypingSpeed);
        }

    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneIndex + 1);
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
        StartCoroutine(NextScene());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
