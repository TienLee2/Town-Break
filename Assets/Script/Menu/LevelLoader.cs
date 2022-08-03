using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public bool openDoors = true;

    public LoadBar loadBar;

    public Animator animator;

    void Start()
    {

    }

    // Used to load next level.
    public void LoadLevel(int sceneIndex)
    {
        // Play close door animation.
        animator.SetTrigger("Start");
        // Load scene async.
        StartCoroutine(LoadLevelAsync(sceneIndex));
    }

    IEnumerator LoadLevelAsync(int sceneIndex)
    {
        // Delay for door close animation.
        yield return new WaitForSeconds(3f);

        // Loading scene async and getting loading progress.
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        // While loading isn't done.
        while (!operation.isDone)
        {
            // Get loading progress.
            float progress = Mathf.Clamp01(operation.progress / 5f);
            // Load progress to the loadbar.
            loadBar.progress = 1 - progress;
            yield return null;
            // Save loadbar rotation for the next scene.
            loadBar.saveRotation();
        }

        if(operation.isDone)
        {
            yield return new WaitForSeconds(3f);
        }
    }
}
