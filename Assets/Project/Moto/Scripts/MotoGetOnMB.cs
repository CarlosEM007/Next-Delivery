using UnityEngine;

public class MotoGetOnMB : MonoBehaviour, IInteractable
{
    [Header("Transforms")]
    [SerializeField] private Transform seat;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private Transform player;

    [Header("References")]
    [SerializeField] private CharacterController playerController;
    [SerializeField] private PlayerMoveMB playerMove;

    [Header("Moto Info")]
    [SerializeField] private MotoSO motoInfo;

    private string prompt = "Let's Ride!";
    private bool isRiding;

    void Awake()
    {
        motoInfo.motoState = MotoStateEnum.Off;
    }

    public string Prompt
    {
        get { return prompt; }
        set { prompt = value; }
    }

    public bool canInteract => true;

    public void Interact()
    {
        if(isRiding == false)
        {
            playerController.enabled = false;

            playerMove.enabled = false;

            player.SetParent(seat);

            player.localPosition = Vector3.zero;
            player.localRotation = Quaternion.identity;

            isRiding = true;

            prompt = "Get off";

            motoInfo.motoState = MotoStateEnum.On;
        }
        else
        {
            player.SetParent(null);
            player.position = exitPoint.position;
            player.rotation = Quaternion.Euler(0, exitPoint.eulerAngles.y, 0);

            playerController.enabled = true;
            playerMove.enabled = true;

            isRiding = false;

            prompt = "Let's Ride!";

            motoInfo.motoState = MotoStateEnum.Off;
        }
    }
}
