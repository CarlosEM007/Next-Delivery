using UnityEngine;

public class NPCRotationMB : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, cam.transform.eulerAngles.y, 0f);
    }
}
