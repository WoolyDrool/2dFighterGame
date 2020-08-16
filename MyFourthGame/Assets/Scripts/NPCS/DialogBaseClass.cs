
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace DialogSystem 
{
public class DialogBaseClass : MonoBehaviour
{
    protected IEnumerator WriteText(string input, Text textHolder, float delay, AudioClip sound)
    {
        textHolder.text = "";
        //textHolder.color = textColor;
        for(int i=0; i<input.Length; i++)
        {
            textHolder.text += input[i];
            SoundManager.instance.PlaySound(sound);
            yield return new WaitForSeconds(delay);
        }
    }
   
}

}

