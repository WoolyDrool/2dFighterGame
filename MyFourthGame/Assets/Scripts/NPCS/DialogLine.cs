using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace DialogSystem{
public class DialogLine : DialogBaseClass
{
    [Header("Text Options")]
    [SerializeField]private string input;
    [SerializeField]Text textHolder;

    [Header("Time parameters")]
    [SerializeField]private float delay;

    [Header("Sound")]
    [SerializeField] private AudioClip sound;

    private void Awake() 
    {
        textHolder = GetComponent<Text>();

        StartCoroutine(WriteText(input, textHolder, delay, sound));
    }
}
}
