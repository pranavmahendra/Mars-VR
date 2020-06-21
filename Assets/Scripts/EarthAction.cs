using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class EarthAction : MonoBehaviour
{
    private string Para1;

    public UnityEvent TextCompleted;

    private string currentText;
    private float delay = 0.01f;

    public TextMeshProUGUI textMesh;

    void Start()
    {
        
        Para1 = "This dot in the sky is our home. The only habitable planet in the solar system. " +
            "The minimum distance from the Earth to Mars is about 54.6 million kilometers. " +
            "The farthest apart they can be is about 401 million km. The average distance is about 225 million km." +
            "" +
            "The first person to ever calculate the distance to Mars was the astronomer Giovanni Cassini, famous for his observations of Saturn. " +
            "Giovanni made observations of Mars in 1672 from Paris, while his colleague, Jean Richer made the same observation from Cayenne, French Guiana. " +
            "They used the parallax method to calculate the distance to Mars with surprising accuracy.";

        StartCoroutine(ShowText());
    }

    public void setCanvasActive()
    {
        gameObject.SetActive(true);
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < Para1.Length ; i++)
        {
            currentText = Para1.Substring(0, i);
            textMesh.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(5);

        TextCompleted.Invoke();


        this.gameObject.SetActive(false);

    }
}
