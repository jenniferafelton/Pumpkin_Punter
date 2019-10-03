using UnityEngine;

public class Fan : MonoBehaviour {
    [SerializeField]
    private float fanSpeed = 10.0f;

    [SerializeField]
    private float fanReach = 5.0f;

    private LayerMask dropLayer;
    private float fanSpeedMultiplier = 50.0f;
    #region MonoBehaviour
    private void Start() {
        dropLayer = LayerMask.GetMask("Drops");
    }

    private void Update() {
        float radius = ((transform.localScale.x + transform.localScale.z) * 0.5f) * 0.5f;
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, transform.up, fanReach, dropLayer);
        foreach (RaycastHit hit in hits) {
            hit.rigidbody.AddForce(FanForce());
        }
    }

    private Vector3 FanForce() {
        return transform.up * fanSpeed * fanSpeedMultiplier * Time.deltaTime;
    }
    #endregion
}