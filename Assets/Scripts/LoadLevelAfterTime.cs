using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAfterTime : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private string sceneNameToLoad;

    private float timeElaspsed;

    private void Update()
    {
        timeElaspsed += Time.deltaTime;
        if (timeElaspsed > delayBeforeLoading)
        {

            SceneManager.LoadScene(sceneNameToLoad);

        }
    }
}