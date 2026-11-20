using UnityEngine;

[CreateAssetMenu(fileName = "GunInfoSO", menuName = "Scriptable Objects/GunInfoSO")]
public class GunInfoSO : ScriptableObject
{
    public float reloadTime = 0f;
    public int bullets = 0;
}
