using UnityEngine;
using UnityEngine.UI;

public class TransitionButton : MonoBehaviour
{
    public string levelToLoad;

    private SceneTransition sceneTransition;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(StartTransition);
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    private void StartTransition()
    {
        sceneTransition.StartTransition(levelToLoad);
    }
}
