using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour {
    public void OnRetryClicked() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}