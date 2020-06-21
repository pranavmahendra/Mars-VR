using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class SunAction : MonoBehaviour
{
    private string Para1;

    [SerializeField] private GameObject Label;

    bool TextWritten = false;

    public UnityEvent TextCompleted;

    private string currentText;
    private float delay = 0.01f;

    public TextMeshProUGUI textMesh;

    void Start()
    {
        
        Para1 = "Mars orbits the Sun at an average distance of 228 million km , " +
            "or 1.524 astronomical units (over one and a half times the distance between Earth and the Sun). " +
            "However, Mars also has the second most eccentric orbit of all the planets in the Solar System , " +
            "which makes it a distant second to Mercury. " +
            "" +
            "This means that Mars’ distance from the Sun varies between perihelion " +
            "(its closest point) and aphelion (its farthest point). In short, the distance between Mars and the Sun ranges during" +
            " the course of a Martian year from 206,700,000 km at perihelion and 249,200,000 km at aphelion – or 1.38 AU and 1.666 AU. ";

        StartCoroutine(ShowText());
    }

    public void setCanvasActive()
    {
        gameObject.SetActive(true);
    }

    IEnumerator ShowText()
    {

        for (int i = 0; i < Para1.Length; i++)
        {
            currentText = Para1.Substring(0, i);
            textMesh.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(5);

        TextCompleted.Invoke();

        gameObject.SetActive(false);

        TextWritten = true;

    }



    public void Deactive()
    {
        Invoke("deactivateCall", 10f);
    }

    private void deactivateCall()
    {
        if (TextWritten)
        {
            gameObject.SetActive(false);
            Label.gameObject.SetActive(true);

        }

    }

}
