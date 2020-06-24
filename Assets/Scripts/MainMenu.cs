using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //create fadeIn and fadeOut of Image
    [SerializeField] Image MenuImage;
    [SerializeField] Image Logo;
    //Fade out of text
    [SerializeField] Text text1;

    void Start()
    {
        StartCoroutine(Fade());

        StopCoroutine(StartCoroutine(Fade()));

        StartCoroutine(FadeText());

        StopCoroutine(StartCoroutine(FadeText()));
    }

    //Fade Logic
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(8f);
        for (float ft = 1f; ft >= 0; ft -= 0.05f)
        {
            Color c = MenuImage.color;
            Color logo = Logo.color;
            c.a = ft;
            logo.a = ft;
            MenuImage.color = c;
            Logo.color = logo;
            yield return null;
        }
        MenuImage.gameObject.SetActive(false);
        Logo.gameObject.SetActive(false);

    }

    //Fade in and fade out
    IEnumerator FadeText()
    {
   
        yield return new WaitForSeconds(8f);
        for (float ft = 1f; ft >= 0; ft -= 0.05f)
        {
            Color text = text1.color;
            text.a = ft;
            text1.color = text;
            yield return  null;
        }
        text1.gameObject.SetActive(false);
    }
}
