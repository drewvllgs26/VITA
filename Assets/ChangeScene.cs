using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private int targetSceneID;

    public void MoveToScene(int sceneID)
    {
        targetSceneID = sceneID;
        StartCoroutine(LoadSceneWithDelay(sceneID, 0.5f));
    }

    private IEnumerator LoadSceneWithDelay(int sceneID, float delayTime)
    {
        yield return new WaitForSeconds(delayTime); 
        SceneManager.LoadScene(sceneID);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            DisableAnimators(scene);
        }

        GameObject player = GameObject.FindGameObjectWithTag("Firefly");
        if (player != null)
        {
            Animator playerAnimator = player.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.enabled = true;
            }
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void DisableAnimators(Scene scene)
    {
        Animator[] animators = FindObjectsOfType<Animator>();
        foreach (Animator animator in animators)
        {
            animator.enabled = false;
        }
    }

    public void closeApplication()
    {
        Application.Quit();
    }

    public void DisableAnimatorinHome()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Info");
        if (player != null)
        {
            Animator playerAnimator = player.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.enabled = false; 
            }
        }
    }
}




