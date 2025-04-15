using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    [SerializeField]
    private float SlowMotionFactor = 0.1f;
    public void StartSlowMotion()
    {
        Time.timeScale = SlowMotionFactor;
    }
    public void StopSlowMotion()
    {
        Time.timeScale = 1f;
    }
}
