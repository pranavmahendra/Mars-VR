using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFocus : MonoBehaviour
{

    [SerializeField]
    Transform reference;
    public float fadeAmount;
    public float delta;

    void Awake()
    {
        reference = Camera.main.gameObject.transform;
    }
    
    void Start()
    {
        
        Debug.DrawLine(reference.transform.position, transform.position,Color.magenta);

        
    }

    
    void Update()
    {
        
    }
}
