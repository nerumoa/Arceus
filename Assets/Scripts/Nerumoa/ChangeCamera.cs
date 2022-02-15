using Cinemachine;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCamera = default;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") {
            var current = Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera as CinemachineVirtualCamera;
            current.Priority = 0;
            vCamera.Priority = 100;
        }
    }
}
