
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace DialogSystem 
{
public class DialogBaseClass : MonoBehaviour
{
    public bool finished {get; private set;}
    
    protected IEnumerator WriteText(string input, Text textHolder, float delay, float delayBetweenLine)
    {
        textHolder.text = "";
        //textHolder.color = textColor;
        for(int i=0; i<input.Length; i++)
        {
            textHolder.text += input[i];
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitUntil(() => Input.anyKey);
        DialogHolder.instance.Restart();
        finished = true;
    }
   
}

}

