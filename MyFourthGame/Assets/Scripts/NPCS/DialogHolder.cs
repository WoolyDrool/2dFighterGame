
using UnityEngine;
using System.Collections;

namespace DialogSystem {
public class DialogHolder : MonoBehaviour
    {
        public static DialogHolder instance;
        public void Awake()
        {
            instance = this;
            StartCoroutine(dialogSequence());
        }

        private IEnumerator dialogSequence()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetComponentInChildren<DialogLine>().finished);
            }
            gameObject.SetActive(false);
        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        public void Restart()
        {
            StartCoroutine(dialogSequence());
        }

    }
}
