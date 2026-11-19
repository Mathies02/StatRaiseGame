
using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text dialogueText;
    public float typingSpeed = 0.05f;

    void Start()
    {
        ShowText("You ended up overworking yourself...");
    }

    public void ShowText(string text)
    {
        StopAllCoroutines();
        StartCoroutine(TypeText(text));
    }

    IEnumerator TypeText(string text)
    {
        dialogueText.text = text;
        dialogueText.maxVisibleCharacters = 0;

        for (int i = 0; i <= text.Length; i++)
        {
            dialogueText.maxVisibleCharacters = i;

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
