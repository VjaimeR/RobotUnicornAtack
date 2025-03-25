using System.Collections.Generic;
using UnityEngine;


public class PlatformsInstantiate : MonoBehaviour
{
    /*[SerializeField]
    private List <GameObject> platforms;
    [SerializeField]   
    private float distanceBetweenPlatforms = 0f;
    [SerializeField]
    private int initialPlatforms = 10; 
    private float offsetPositionX = 0f;
    [SerializeField]
    private int specificPlatform1Index = 0;
    [SerializeField]
    private int specificPlatform2Index = 1;*/

    /*private void Start()
    {
        offsetPositionX = 0;
        InstantiateInitialPlatforms();
        InstantiateRandomPlatforms(initialPlatforms - 2);
    }
    private void InstantiateInitialPlatforms()
    {
        if (specificPlatform1Index < 0 || specificPlatform1Index >= platforms.Count ||
            specificPlatform2Index < 0 || specificPlatform2Index >= platforms.Count)
        {
            Debug.LogError("�ndices de plataforma espec�fica fuera de rango.");
            return;
        }

        InstantiatePlatform(platforms[specificPlatform1Index]);
        InstantiatePlatform(platforms[specificPlatform2Index]);
    }
    private void InstantiateRandomPlatforms(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, platforms.Count);
            InstantiatePlatform(platforms[randomIndex]);
        }
    }

    void InstantiatePlatform(GameObject platformPrefab)
    {
        if (offsetPositionX != 0)
        {
            offsetPositionX += (float)(platformPrefab.GetComponent<BoxCollider>().size.x * 0.5);
        }
        GameObject platform = Instantiate(platformPrefab, Vector3.zero, Quaternion.identity);
        offsetPositionX += distanceBetweenPlatforms + platformPrefab.GetComponent<BoxCollider>().size.x * 0.5f;
        platform.transform.SetParent(transform);
        platform.transform.localPosition = new Vector3(offsetPositionX, 0, 0);
    }

    // M�todo para reiniciar la escena
     void Restart()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Start();
    }*/
    [SerializeField]
    private List<GameObject> platforms;
    [SerializeField]
    private List<GameObject> safePlatforms;
    [SerializeField]
    private float distanceBetweenPlatforms = 2f;
    [SerializeField]
    private int initialPlatforms = 10;
    private float offsetPositionX = 0f;
    private int platformsIndex = 0;

    private void Start()
  {
      platformsIndex = 0;
      offsetPositionX = 0;
      InstantiatePlatforms(initialPlatforms);
  }


  public void InstantiatePlatforms(int amount)
  {
    
      for (int i = 0; i < amount; i++)
      {
          List<GameObject> platformsToUse = platformsIndex < 2 ? safePlatforms : platforms;
          int randomIndex = Random.Range(0, platformsToUse.Count);
          if (offsetPositionX != 0)
          {
              offsetPositionX += platformsToUse[randomIndex].GetComponent<BoxCollider>().size.x * 0.5f;
          }
          GameObject platform = Instantiate(platformsToUse[randomIndex], Vector3.zero, Quaternion.identity);
          offsetPositionX += distanceBetweenPlatforms + platform.GetComponent<BoxCollider>().size.x * 0.5f;
          platform.transform.SetParent(transform);
          platform.transform.localPosition = new Vector3(offsetPositionX, 0,0);
          platformsIndex++;
      }
  }

  public void Restart()
  {
      foreach (Transform child in transform)
      {
          Destroy(child.gameObject);
      }
      Start();
  }


}

