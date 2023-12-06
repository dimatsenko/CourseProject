using UnityEngine;

public class ExcavationSite : MonoBehaviour
{
    public ChatManager chatManager;
    public GameObject artifactPrefab; // Префаб артефакту
    public MetalDetector metalDetector;
    public PlayerBalance playerBalance;

    public void StartExcavation()
    {
        Debug.Log("Розпочато розкопку!");

        if (metalDetector != null && metalDetector.IsDetecting)
        {
            Debug.Log("Metal detector is actively detecting.");
            InitializeArtifact(true);
        }
        else
        {
            Debug.Log("Metal detector is not actively detecting.");
            InitializeArtifact(false);
        }

    
    }

    void InitializeArtifact(bool isHighValue)
    {
        bool artifactFound = Random.value > 0.1f;

        if (artifactFound)
        {
            // Створюємо артефакт як групу
            GameObject artifactObject = Instantiate(artifactPrefab, transform.position, Quaternion.identity);

            // Отримуємо компонент артефакту
            Artifact artifact = artifactObject.GetComponent<Artifact>();
            if (artifact != null)
            {
                if (isHighValue)
                {
                    // Ініціалізація артефакту з високим шансом
                    artifact.GenerateHighValueArtifact();
                    chatManager.AddMessage($"Знайдено артефакт: {artifact.name} вартістю {artifact.value} монет.");
                    playerBalance.AddCoins(artifact.value);
                }
                else
                {
                    // Звичайна ініціалізація артефакту
                    artifact.GenerateArtifactData();
                    chatManager.AddMessage($"Знайдено артефакт: {artifact.name} вартістю {artifact.value} монет.");
                      playerBalance.AddCoins(artifact.value);
                }
            }
        }
        else
        {
            chatManager.AddMessage("Нічого не знайдено.");
        }
    }
}
