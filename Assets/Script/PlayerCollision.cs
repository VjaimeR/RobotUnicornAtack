using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]

    private UnityEvent onPlayerLose;
    [SerializeField]
    private UnityEvent<Transform> onObstacleDestroy;
    [SerializeField]
    private UnityEvent<Transform> onCollisionDie;
    [SerializeField]
    private  UnityEvent onCoinCollected;
  
    private Dash dash;

    private void Start()
    {
        dash =  GetComponent<Dash>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
          if (dash.IsDashing)
          {
            onObstacleDestroy?.Invoke(transform);
            collision.gameObject.SetActive(false);
          }
          else
          {
             onCollisionDie?.Invoke(transform);
             onPlayerLose?.Invoke();
                //Activa el Low Pitch
             SoundManager.instance.LowerMusicPitch(0.5f, 2f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
             onCollisionDie?.Invoke(transform);
             onPlayerLose?.Invoke();
        }
        else if (other.CompareTag("Coin"))
        {
         other.gameObject.SetActive(false);
         onCoinCollected?.Invoke();
        }
    }
}
