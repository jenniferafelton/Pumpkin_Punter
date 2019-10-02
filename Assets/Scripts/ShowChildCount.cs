using UnityEngine;

public class ShowChildCount : MonoBehaviour {
    [SerializeField]
    private bool showChildCount = true;

    private string originalName;
    private int lastCount = -1;

    void Start() {
        originalName = gameObject.name;
    }

    void Update() {
        if (showChildCount && (transform.childCount != lastCount)) {
            gameObject.name = $"{originalName} ({transform.childCount})";
            lastCount = transform.childCount;
        }
    }
}
