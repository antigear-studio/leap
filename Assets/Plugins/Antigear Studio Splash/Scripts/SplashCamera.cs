using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashCamera : MonoBehaviour {
    public float panSpeed = 5.0f;

    public Vector3 goal = new Vector3(5.8f, 0, -10);
    public float size = 8;

    public TextMesh title;

    public Vector3 maskGoal;

    public Transform mask;

    public int targetScene;

    AsyncOperation loading;

    bool cutsceneDone;

    // Use this for initialization
    void Start() {
        StartCoroutine(Action());
        loading = SceneManager.LoadSceneAsync(targetScene);
        loading.allowSceneActivation = false;
    }

    void Update() {
        if (loading != null)
            loading.allowSceneActivation |= cutsceneDone;
    }

    IEnumerator Action() {
        yield return new WaitForSeconds(2.0f);

        Color s = new Color(233 / 255f, 233 / 255f, 233 / 255f);

        while (Camera.main.orthographicSize < size - 0.02f) {
            float amt = Time.deltaTime * panSpeed + 0.05f;
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, size, amt);
            transform.position = Vector3.Lerp(transform.position, goal, amt);
            title.color = Color.Lerp(title.color, s, 3 * amt);

            yield return null;
        }

        yield return new WaitForSeconds(1.0f);


        // Wipe out
        float t = 0;
        while (t < 1) {
            t += Time.deltaTime;
            mask.position = Vector2.Lerp(mask.position, maskGoal, t);

            yield return null;
        }

        cutsceneDone = true;
    }
}
