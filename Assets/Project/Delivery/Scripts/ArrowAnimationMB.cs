using UnityEngine;

public class ArrowAnimationMB : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float height;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * height;

        transform.localPosition = startPosition + Vector3.up * offset;
    }
}
