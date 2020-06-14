using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialGradient : MonoBehaviour
{

    private Renderer textRenderer;
    [SerializeField]
    ObjectFocus objectFocus;

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
         objectFocus = gameObject.GetComponentInParent<ObjectFocus>();
    }

  
    void Start()
    {
        //Starting gradient pos value.
        gradientPos = 1;
    }

   
    void Update()
    {
         setGradientPos(objectFocus.fadeAmount);
    }
}
