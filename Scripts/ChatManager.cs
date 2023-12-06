using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ChatManager : MonoBehaviour
{
    public Text chatText;
    public int maxMessages = 5; // ����������� ������� ���������� ��� ���������
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
        messages.Enqueue(message); // ������ ����������� � �����

        if (messages.Count > maxMessages)
        {
            messages.Dequeue(); // ��������� ��������� �����������, ���� ������� �������� �����������
        }

        // ��������� ���� ����� �� ����� ���������� � ���� � ����������� �������
        chatText.text = string.Join("\n", messages.Reverse().ToArray());
    }
}