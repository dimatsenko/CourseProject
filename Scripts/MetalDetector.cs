using UnityEngine;

public class MetalDetector : ExcavationSite

{
    public PlayerBalance playerBalance;
    public ChatManager chatManager;
    public KeyCode activationKey = KeyCode.Q;
    public float activationHoldTime = 2f;
    public float DetectionProgress => activationHoldTimer / activationHoldTime;
    public bool isActivationKeyHeld = false;
    public float activationHoldTimer = 0f;

    public float detectionDuration = 10f;
    private bool isDetecting = false;
    private float detectionTimer = 0f;
    public bool IsDetecting => isDetecting;

  


    void Update()
    {
        HandleActivationKey();

        if (isActivationKeyHeld)
        {
            ContinueHoldind();
        }

        if (isDetecting)
        {
            ContinueTimer();

        }
    }

    void HandleActivationKey()
    {
        if (Input.GetKey(activationKey))
        {
            activationHoldTimer += Time.deltaTime;

            if (activationHoldTimer >= activationHoldTime && !isActivationKeyHeld)
            {
                isActivationKeyHeld = true;
                StartDetectionTimer();
                Debug.Log("Metal detector activated!");
            }
        }
        else
        {
            activationHoldTimer = 0f;
            isActivationKeyHeld = false;
           
        }
    }

    void ContinueHoldind()
    {
        activationHoldTimer += Time.deltaTime;

        if (activationHoldTimer >= activationHoldTime)
        {
            StopHolding();
        }
    }

    void StopHolding()
    {
       
        detectionTimer = 0f;
    }

    void StartDetectionTimer()
    {
        Debug.Log("StartDetectionTimer called");
        if (playerBalance != null)
        {
            playerBalance.DeductFromBalance(20);
            Debug.Log("Deducted 10 coins from player's balance");
        }
        else
        {
            Debug.LogError("PlayerBalance reference is null!");
        }

        if (Random.value <= 0.3f)
        {
            isDetecting = true;
             chatManager.AddMessage("Металошукач щось знайшов");
            Debug.Log("Metal detection started!");
        }
        else
        {
            chatManager.AddMessage("Металошукач нічого не знайшов");
        }


      }
            


    void ContinueTimer()
    {
        detectionTimer += Time.deltaTime;
     
        if (detectionTimer >= detectionDuration)
        {
            StopTimer();
        }
    }

    void StopTimer()
    {
        isDetecting = false;
    }
}
