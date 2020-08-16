using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace DialogSystem{
public class DialogLine : DialogBaseClass
{
    [Header("Text Options")]
    [SerializeField]private string input;
    [SerializeField]Text textHolder;
    [SerializeField] float delayBetweenLine;

    [Header("Time parameters")]
    [SerializeField]private float delay;


    private void Awake() 
    {
        textHolder = GetComponent<Text>();
    }

    private void Start() 
    {
        StartCoroutine(WriteText(input, textHolder, delay, delayBetweenLine));
    }
}
}
