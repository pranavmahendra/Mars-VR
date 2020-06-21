using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurosityAction : MonoBehaviour
{
    public bool hasPlayed = false;
    private Animator animator;
    [SerializeField] private GameObject label;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public void PlayAnimation()
    {
        if(hasPlayed == false)
        {
            label.SetActive(false);
            hasPlayed = true;
            animator.SetBool("PlayAnim", hasPlayed);
            Invoke("SetFalse", 26f);
   
        }

    }

    public void SetFalse()
    {
        hasPlayed = false;
        animator.SetBool("PlayAnim", hasPlayed);
        label.SetActive(true);
    }
        
 
}
