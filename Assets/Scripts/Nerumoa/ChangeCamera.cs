using Cinemachine;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCamera = default;
    [SerializeField] Collider2D confiner1 = default;
    [SerializeField] Collider2D confiner2 = default;

    [SerializeField] bool inversion = false;

    CinemachineConfiner cc;

    private void Start()
    {
        cc = vCamera.gameObject.GetComponent<CinemachineConfiner>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) {
            if (inversion) {
                confiner1.gameObject.SetActive(true);
                cc.m_BoundingShape2D = confiner1;
                confiner2.gameObject.SetActive(false);
            } else {
                confiner2.gameObject.SetActive(true);
                cc.m_BoundingShape2D = confiner2;
                confiner1.gameObject.SetActive(false);
            }
        }
    }
}
