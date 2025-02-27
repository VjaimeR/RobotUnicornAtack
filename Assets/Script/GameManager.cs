using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnGameStart;

    void Start()
    {
        OnGameStart?.Invoke();
    }
}
