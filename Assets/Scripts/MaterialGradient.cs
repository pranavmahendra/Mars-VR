using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialGradient : MonoBehaviour
{

    private Renderer textRenderer;

    [SerializeField]
    Gradient gradient;
    private float gradientPos; //GradientPos will chnage as per the angle values derived from camera
    void setGradientPos(float position)
    {
        if(position == gradientPos)
        {
            return;
        }
        else
        {
            gradientPos = position;
            textRenderer.material.color = gradient.Evaluate(gradientPos);
        }
    }

    void Awake()
    {
         textRenderer = gameObject.GetComponent<Renderer>();
    }

  
    void Start()
    {
        //Starting gradient pos value.
        gradientPos = 0;
    }

   
    void Update()
    {
         setGradientPos(Mathf.Sin(((Time.time) * 0.5f) + 0.5f));
    }
}
