using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public UnityAction<int> scoreChange;

    private int _score;
    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreChange(value);
        }
    }

}
