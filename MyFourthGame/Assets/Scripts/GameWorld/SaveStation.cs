using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveStation : MonoBehaviour
{
    public TextMeshProUGUI Prompt;
    public GameObject levelUpScreen;
    // Start is called before the first frame update
    void Start()
    {
        Prompt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Entered trigger");
        if(other.tag == "Player")
        {
            Prompt.gameObject.SetActive(true);

            if(Input.GetButton("General Interact"))
            {
                Debug.Log("Opened level screen");
                levelUpScreen.gameObject.SetActive(true);
            }
        }

    }
}
