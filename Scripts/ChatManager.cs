using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ChatManager : MonoBehaviour
{
    public Text chatText;
    public int maxMessages = 5; // Максимальна кількість повідомлень для зберігання
    private Queue<string> messages = new Queue<string>();

    void Start()
    {
        ClearChat();
    }

    void ClearChat()
    {
        chatText.text = "";
    }

    public void AddMessage(string message)
    {
        messages.Enqueue(message); // Додаємо повідомлення в чергу

        if (messages.Count > maxMessages)
        {
            messages.Dequeue(); // Видаляємо найстарше повідомлення, якщо кількість перевищує максимальну
        }

        // Оновлюємо весь текст на основі повідомлень у черзі у зворотньому порядку
        chatText.text = string.Join("\n", messages.Reverse().ToArray());
    }
}