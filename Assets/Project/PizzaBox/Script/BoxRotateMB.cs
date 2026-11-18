using UnityEngine;

public class BoxRotateMB : MonoBehaviour
{
    [Header("Axis Values")]
    [SerializeField] private float axisX;
    [SerializeField] private float axisY;
    [SerializeField] private float axisZ;
    [SerializeField] private float speed;

    void Update()
    {
        transform.Rotate(new Vector3(axisX, axisY, axisZ) * Time.deltaTime * speed);
    }
}
