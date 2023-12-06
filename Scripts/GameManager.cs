using UnityEngine;

public class PlayerBalance : MonoBehaviour
{
    public static PlayerBalance instance;

    private int coins = 0;

    public int Coins => coins;

    public bool IsBankrupt => coins < -100;

    public bool IsMissionCompleted => coins > 1000;



    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.white;

        // Check for bankruptcy
        if (coins < -100)
        {
            GUI.Label(new Rect(Screen.width / 2 - 70, 10, 140, 30), "�� �������!", style);
        }
        // Check for mission completion
        else if (coins > 1000)
        {
            GUI.Label(new Rect(Screen.width / 2 - 70, 10, 160, 30), "̳�� ��������!", style);
        }
        // Display the player's balance at the top center of the screen
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 70, 10, 100, 30), $"������: {coins} �����", style);
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public void DeductFromBalance(int amount)
    {
        coins -= amount;
    }

   

    public string GetStatusLabel()
    {
        

        if (coins < -100)
        {
            return "�� �������!";
        }
        else if (coins > 1000)
        {
            return "̳�� ��������!";
        }
        else
        {
            return $"������: {coins} �����";
        }
    }
}
