using UnityEngine;

[CreateAssetMenu(fileName = "MotoSO", menuName = "Scriptable Objects/MotoSO")]
public class MotoSO : ScriptableObject
{
    [Header("Moto State")]
    public MotoStateEnum motoState;

    [Header("Moto Info")]
    public float speed = 15f;
    public float turnSpeed = 90f;
    public float gravity = -20f;
    public float stayGroundForce = -2f;
}
