using UnityEngine;

public class Spout : MonoBehaviour {
    [SerializeField]
    private KeyCode sprayKey = KeyCode.Space;
    [SerializeField]
    private GameObject dropPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float spoutPower = 5.0f;
    [SerializeField]
    private float dirRandomness = 5.0f;
    [SerializeField]
    private Transform dropContainer;

    private void Start() {
        if (dropContainer == null) {
            GameObject go = new GameObject("Drops");
            go.AddComponent<ShowChildCount>();
            dropContainer = go.transform;
        }
    }

    private void Update() {
        if (Input.GetKey(sprayKey)) {
            Spray();
        }
    }

    private void Spray() {
        GameObject go = Instantiate(dropPrefab, spawnPoint.position, Quaternion.identity, dropContainer);

        go.GetComponent<Renderer>().material.SetColor("_Color", new Color().Random());
        go.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color().Random());

        go.GetComponent<Rigidbody>().velocity = (transform.up * spoutPower) + RandDirection();
    }

    private Vector3 RandDirection() {
        return new Vector3(
            UnityEngine.Random.Range(-dirRandomness, dirRandomness),
            0,
            UnityEngine.Random.Range(-dirRandomness, dirRandomness)
        );
    }
}
