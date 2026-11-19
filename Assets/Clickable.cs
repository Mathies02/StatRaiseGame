using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    public enum TextType
    {
        Assets,
        JobRank,
        Connections
    }

    public GameManager gameManager;

    [Header("Interaction Settings")]
    [TextArea] public string message;

    [Header("Counter Settings")]
    public TMP_Text ObjectToIncrease;
    public TextType selectedText;
    public int counter = 0;
    public int amountToGain = 0;
    private int innerValueGain = 2;
    private int innerValueLoss = 1;

    void Start()
    {
        UpdateText();
    }   

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(message);

        if (ObjectToIncrease != null)
        {
            IncreaseCounter(amountToGain);
            DecreaseInnerValue(innerValueLoss);
        }
        else
        {
            IncreaseInnerValue(innerValueGain);
        }
    }

    public void IncreaseCounter(int amount)
    {
        counter += amount;
        UpdateText();
    }

    public void IncreaseInnerValue(int amount)
    {
        gameManager.innerValue += amount;
    }

    public void DecreaseInnerValue(int amount)
    {
        gameManager.innerValue -= amount;
    }

    void UpdateText()
    {
        if (ObjectToIncrease == null)
            return;

        switch (selectedText)
        {
            case TextType.Assets:
                ObjectToIncrease.text = $"Assets: {counter}$";
                break;

            case TextType.JobRank:
                ObjectToIncrease.text = $"Job Rank: {counter}";
                break;

            case TextType.Connections:
                ObjectToIncrease.text = $"Connections: {counter}";
                break;
        }
    }
}