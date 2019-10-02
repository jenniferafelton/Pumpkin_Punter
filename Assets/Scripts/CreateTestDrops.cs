using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTestDrops : MonoBehaviour {
    [SerializeField]
    private GameObject dropPrefab;

    [SerializeField]
    private float creationHeight = 5.0f;

    [SerializeField]
    private float positionSpan = 4.5f;

    [SerializeField]
    private int count = 1000;

    [SerializeField]
    private int perFrame = 100;

    private void OnEnable() {
        StartCoroutine(CreateDrops());
    }

    private IEnumerator CreateDrops() {
        var pause = new WaitForEndOfFrame();
        for (int i = 0; i < count; i++) {
            Vector3 ranPos = new Vector3(
                Random.Range(-positionSpan, positionSpan),
                creationHeight,
                Random.Range(-positionSpan, positionSpan));

            GameObject go = Instantiate(dropPrefab, ranPos, Quaternion.identity, transform);
            gameObject.name = $"TestDrops ({transform.childCount})";

            go.GetComponent<Renderer>().material.SetColor("_Color", RandomColor());
            go.GetComponent<Renderer>().material.SetColor("_EmissionColor", RandomColor());

            if (i % 100 == 0) {
                yield return pause;
            }
        }
    }

    private Color RandomColor() {
        return new Color(
            Random.value,
            Random.value,
            Random.value
        );
    }
}
