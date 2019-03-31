using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Directions : MonoBehaviour {

    static bool newSuggestion = false;
    static string suggest = "";
    Text t;

    void Awake()
    {
        t = GetComponent<Text>();
    }

    void Update()
    {
        if (newSuggestion)
        {
            t.text = suggest;
            Debug.Log(t.text);
            Debug.Log(suggest);
            newSuggestion = false;
            StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
        }
    }


    public void newDirection(string s)
    {
        suggest = s;
        newSuggestion = true;
        Debug.Log(s);
    }


    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
