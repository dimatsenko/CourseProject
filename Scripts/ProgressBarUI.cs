using UnityEngine;

public class ExcavationProgressBarUI : MonoBehaviour
{
    public ArchaeologyInteraction archaeologyInteraction; // ����� ��� ��'���� � ����� ��������
    public float barWidth = 40f;
    public float barHeight = 7f;
    public float yOffset = -50f; // ������ ������� ���� ������

    void OnGUI()
    {
        if (archaeologyInteraction.IsExcavating)
        {
            DrawExcavationProgressBar();
        }
    }

    void DrawExcavationProgressBar()
    { if (archaeologyInteraction.excavationTimer < archaeologyInteraction.excavationDuration)
        {
            GUI.color = Color.green;
            float barProgress = barWidth * archaeologyInteraction.ExcavationProgress;

            float screenCenterX = Screen.width * 0.5f;
            float screenCenterY = Screen.height * 0.5f;
            float barPositionX = screenCenterX - barWidth * 0.5f;
            float barPositionY = screenCenterY + yOffset;

            GUI.DrawTexture(new Rect(barPositionX, barPositionY, barProgress, barHeight), Texture2D.whiteTexture);
        }
        GUI.color = Color.white;
    }
}