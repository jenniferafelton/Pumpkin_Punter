using UnityEngine;

[RequireComponent(typeof(Collider))]
public class KillZone : MonoBehaviour {

    private LayerMask dropsLayer;

    private void Awake() {
        dropsLayer = LayerMask.NameToLayer("Drops");
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == dropsLayer) {
            Destroy(other.gameObject);
        }
    }
}
