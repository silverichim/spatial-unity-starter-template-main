using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int points;
    private int prepoints;
    public TextMeshProUGUI pLabel;

    private int coins;
    private int precoins;
    public TextMeshProUGUI cLabel;
    private int currentSelection;
    private bool isActive;

    private void Start()
    {
        currentSelection = 0;
        points = 0;
        coins = 1000;
        prepoints = 0;
        precoins = 0;
    }
    public void UpdateSelection(int value)
    {
        if (currentSelection != value)
        {
            currentSelection = value;
            isActive = true;
        }
        else isActive = false;
            
    }
    public void UpdatePoints(int value)
    {
        if (isActive)
        {
            points = System.Convert.ToInt32(pLabel.text) - prepoints + value;
            prepoints = value;
            pLabel.text = points.ToString();
        }
    }

    public void UpdateCoins(int value)
    {
        if (isActive)
        {
            coins = System.Convert.ToInt32(cLabel.text) - precoins + value;
            precoins = value;
            cLabel.text = coins.ToString();
        }
            
    }
}
