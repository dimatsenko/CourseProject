using UnityEngine;

public class ExcavationSite : MonoBehaviour
{
    public ChatManager chatManager;
    public GameObject artifactPrefab; // ������ ���������
    public MetalDetector metalDetector;
    public PlayerBalance playerBalance;

    public void StartExcavation()
    {
        Debug.Log("��������� ��������!");

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
            // ��������� �������� �� �����
            GameObject artifactObject = Instantiate(artifactPrefab, transform.position, Quaternion.identity);

            // �������� ��������� ���������
            Artifact artifact = artifactObject.GetComponent<Artifact>();
            if (artifact != null)
            {
                if (isHighValue)
                {
                    // ����������� ��������� � ������� ������
                    artifact.GenerateHighValueArtifact();
                    chatManager.AddMessage($"�������� ��������: {artifact.name} ������� {artifact.value} �����.");
                    playerBalance.AddCoins(artifact.value);
                }
                else
                {
                    // �������� ����������� ���������
                    artifact.GenerateArtifactData();
                    chatManager.AddMessage($"�������� ��������: {artifact.name} ������� {artifact.value} �����.");
                      playerBalance.AddCoins(artifact.value);
                }
            }
        }
        else
        {
            chatManager.AddMessage("ͳ���� �� ��������.");
        }
    }
}
