using System.Collections.Generic;
using UnityEngine;


public class PlatformsInstantiate : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> platforms;
    [SerializeField]
    private Transform platformPosition;
    [SerializeField]
    private float distanceBetweenPlatforms = 2f;
    [SerializeField]
    private int initialPlatforms = 10;
    private float offsetPositionX = 0f;


    private void Start()
    {
        offsetPositionX = 0;
        InstantiatePlatforms(initialPlatforms);
    }


    public void InstantiatePlatforms(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, platforms.Count);
            if (offsetPositionX != 0)
            {
                offsetPositionX += (float)(platforms[randomIndex].GetComponent<BoxCollider>().size.x * 0.5);
            }
            GameObject platform = Instantiate(platforms[randomIndex], new Vector3(offsetPositionX, platformPosition.position.y, platformPosition.position.z), Quaternion.identity);
            offsetPositionX += distanceBetweenPlatforms + platform.GetComponent<BoxCollider>().size.x * 0.5f;
            platform.transform.SetParent(transform);
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

