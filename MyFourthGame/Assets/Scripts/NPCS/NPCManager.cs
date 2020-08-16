using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogSystem {
public class NPCManager : MonoBehaviour
{
    public string Name = "Tom The Debug Merchant";
    public TextMeshProUGUI Prompt;
    public bool canInteract = false;
    public GameObject dialogHolder;
    // Start is called before the first frame update
    void Start()
    {
        Prompt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("General Interact") && canInteract)
        {
            Debug.Log("Interacted with " + name);
            dialogHolder.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        canInteract = true;
        Debug.Log("Entered trigger");
        if(other.tag == "Player")
        {
            Prompt.gameObject.SetActive(true);
            Debug.Log("Set the prompt to be active");
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        canInteract = false;
        Prompt.gameObject.SetActive(false);
    }
}
}
