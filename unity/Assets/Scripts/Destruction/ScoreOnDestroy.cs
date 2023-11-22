using UnityEngine;

public class ScoreModifier : MonoBehaviour
{

    public int change = 100;

    void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
            return;
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.score += change;
    }
}
