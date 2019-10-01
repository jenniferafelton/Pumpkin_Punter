using System;
using UnityEngine;

public class Ground : MonoBehaviour {
    [SerializeField]
    float blastForce = 5.0f;

    [SerializeField]
    float blastArea = 1.0f;

    private Camera mainCamera;
    private LayerMask groundLayer;
    private LayerMask dropsLayer;
    private float blastForceMultiplier = 100.0f;
    private float blastUpwardModifier = 5.0f;

    private void Start() {
        mainCamera = Camera.main;
        groundLayer = LayerMask.GetMask("Ground");
        dropsLayer = LayerMask.GetMask("Drops");
    }

    void Update() {
        if (Input.GetMouseButton(0) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift))) {
            CheckForDropDelete();
        } else if (Input.GetMouseButtonDown(0)) {
            CheckForGroundClick();
        }
    }

    private void CheckForDropDelete() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit dropHit, 100.0f, dropsLayer)) {
            Destroy(dropHit.collider.gameObject);
        }
    }

    private void CheckForGroundClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit groundHit, 100.0f, groundLayer)) {
            Collider[] hits = Physics.OverlapSphere(groundHit.point, blastArea, dropsLayer);
            foreach (Collider hit in hits) {
                hit.gameObject
                    .GetComponent<Rigidbody>()
                    .AddExplosionForce(TotalBlastForce(), groundHit.point, blastArea, blastUpwardModifier);
            }
        }
    }

    private float TotalBlastForce() {
        return blastForce * blastForceMultiplier;
    }
}
