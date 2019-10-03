using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GroundExplosion : MonoBehaviour {
    [SerializeField]
    float blastForce = 5.0f;

    [SerializeField]
    float blastArea = 1.0f;

    [SerializeField]
    private float blastUpwardMod = 0.25f;

    private Camera mainCamera;
    private LayerMask groundLayer;
    private LayerMask dropsLayer;
    private readonly float blastForceMultiplier = 100.0f;

    private void Start() {
        mainCamera = Camera.main;
        groundLayer = LayerMask.GetMask("Ground");
        dropsLayer = LayerMask.GetMask("Drops");
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CheckForGroundClick();
        }
    }

    private void CheckForGroundClick() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit groundHit, 100.0f, groundLayer)) {
            Explode(groundHit.point);
        }
    }

    private void Explode(Vector3 targetPos) {
        Collider[] hits = Physics.OverlapSphere(targetPos, blastArea, dropsLayer);
        foreach (Collider hit in hits) {
            hit.gameObject
                .GetComponent<Rigidbody>()
                .AddExplosionForce(TotalBlastForce(), targetPos, blastArea, blastUpwardMod);
        }
    }

    private float TotalBlastForce() {
        return blastForce * blastForceMultiplier;
    }
}