using UnityEngine;

public static class ExtensionMethods {
    public static Color Random(this Color color) {
        color = new Color(
            UnityEngine.Random.value,
            UnityEngine.Random.value,
            UnityEngine.Random.value,
            UnityEngine.Random.value);

        return color;
    }
}