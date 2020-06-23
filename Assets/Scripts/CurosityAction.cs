using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CurosityAction : MonoBehaviour
{
    public bool hasPlayed = false;

    private string Para1;
    private string Para2;
    private string Para3;

    [SerializeField] private TextMeshProUGUI textMesh;

    private string currentText;
    private float delay = 0.01f;

    bool TextWritten = false;

    [SerializeField] private Animator animator;

    public UnityEvent TextCompleted; //Text likhne ke baad animation event call hoga.

    [SerializeField] private GameObject label; //Curosity Label


    private void Start()
    {
        Para1 = "Curiosity is a car-sized rover designed to explore the crater Gale on Mars as part of NASA's Mars Science Laboratory mission (MSL)." +
        " Curiosity was launched from Cape Canaveral on November 26th, 2011, at 15:02 UTC and landed on Aeolis Palus inside Gale on Mars on August 6th, 2012.";

        Para2 = "Dimensions: Curiosity has a mass of 899 kg (1,982 lb) including 80 kg (180 lb) of scientific instruments.[23] The rover is 2.9 m (9.5 ft) long by 2.7 m (8.9 ft) wide by 2.2 m (7.2 ft) in height." +
        "  " +
        "Power source: Curiosity is powered by a radioisotope thermoelectric generator.";

        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {

        for (int i = 0; i < Para1.Length; i++)
        {
            currentText = Para1.Substring(0, i);
            textMesh.text = currentText;
            yield return new WaitForSeconds(delay);
            currentText = "";
        }
        yield return new WaitForSeconds(5);

        for (int i = 0; i < Para2.Length; i++)
        {
            currentText = Para2.Substring(0, i);
            textMesh.text = currentText;
            yield return new WaitForSeconds(delay);
            currentText = "";
        }
        yield return new WaitForSeconds(5);

        TextCompleted.Invoke();

        gameObject.SetActive(false);

        TextWritten = true;

    }

    public void PlayAnimation()
    {
        if (hasPlayed == false)
        {

            hasPlayed = true;
            animator.SetBool("PlayAnim", hasPlayed);
            Invoke("SetFalse", 26f);

        }

    }

    //Animation complete hone ke baad ye call hojayega.
    public void SetFalse()
    {
        hasPlayed = false;
        animator.SetBool("PlayAnim", hasPlayed);
        label.SetActive(true);
    }


    public void Deactive()
    {

        deactivateCall();
    }

    private void deactivateCall()
    {
        if (TextWritten)
        {
            TextCompleted.Invoke();
            gameObject.SetActive(false);
        }

    }

}
