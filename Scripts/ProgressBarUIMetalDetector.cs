using UnityEngine;

public class MetalDetectorProgressBarUI : MonoBehaviour
{
    public MetalDetector metalDetector; // «м≥нна дл€ зв'€зку з ≥ншим скриптом
    public float barWidth = 40f;
    public float barHeight = 7f;
    public float yOffset = -50f; // «м≥нена в≥дстань вище центру

    void OnGUI()
    {
        if (metalDetector.activationHoldTimer <= 0f)
        {
            return;
        }
        DrawDetectionProgressBar();
    }

    void DrawDetectionProgressBar()
    {
        if (metalDetector.activationHoldTimer < metalDetector.activationHoldTime)
        {
            GUI.color = Color.blue;
            float barProgress = barWidth * metalDetector.DetectionProgress;

            float screenCenterX = Screen.width * 0.5f;
            float screenCenterY = Screen.height * 0.5f;
            float barPositionX = screenCenterX - barWidth * 0.5f;
            float barPositionY = screenCenterY + yOffset;

            GUI.DrawTexture(new Rect(barPositionX, barPositionY, barProgress, barHeight), Texture2D.whiteTexture);
        }
        GUI.color = Color.white;
    }
}
