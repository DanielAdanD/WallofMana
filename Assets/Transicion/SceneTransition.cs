using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 1f;

    public string levelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartTransition();
        }
    }

    public void StartTransition(string levelToLoad)
    {
        animator.SetTrigger("StartTransition");
        StartCoroutine(LoadSceneAfterTransition(levelToLoad));
    }

    public void StartTransition()
    {
        StartTransition(levelToLoad);
    }

    IEnumerator LoadSceneAfterTransition(string levelToLoad)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelToLoad);
    }
}
