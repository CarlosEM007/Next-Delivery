using UnityEngine;

public class PendulumMB : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float maxAngle;
    [SerializeField] private float rotatationY;

    private void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * maxAngle;

        transform.localRotation = Quaternion.Euler(0f, rotatationY, angle);
    }
}
