using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
   [SerializeField]
   private GameObject _objetToInstantiate;
   public void InstantiateObjectPosition(Transform asset)
   {
    Instantiate(_objetToInstantiate, asset.position, Quaternion.identity);
   }
}
