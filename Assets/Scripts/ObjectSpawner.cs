using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectSpawner : MonoBehaviour
{
    [System.Serializable]
    public class NavmeshObject
    {
        public string name;
        public GameObject prefab;
        [Range(0, 100)]
        public int spawnPercentage;
    }

    public List<NavmeshObject> objectsToSpawn = new List<NavmeshObject>();
    public int totalObjectsToSpawn = 100;
    public float minDistanceBetweenObjects = 2.0f;

    private void Start()
    {
        SpawnObjectsWithPercentage();
    }

    private void SpawnObjectsWithPercentage()
    {
        List<GameObject> navmeshObjects = new List<GameObject>();
        List<Vector3> spawnedPositions = new List<Vector3>();
        foreach (var navmeshObject in objectsToSpawn)
        {
            int numObjects = totalObjectsToSpawn * navmeshObject.spawnPercentage / 100;
            for (int i = 0; i < numObjects; i++)
            {
                Vector3 randomPosition = GetRandomPositionOnNavmesh(spawnedPositions);
                GameObject spawnedObject = Instantiate(navmeshObject.prefab, randomPosition, Quaternion.identity);
                navmeshObjects.Add(spawnedObject);
                spawnedPositions.Add(randomPosition);
            }
        }

        // Shuffle the list of spawned objects
        ShuffleList(navmeshObjects);
    }

    private Vector3 GetRandomPositionOnNavmesh(List<Vector3> spawnedPositions)
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        int randomIndex = Random.Range(0, navMeshData.indices.Length - 3);
        Vector3 v1 = navMeshData.vertices[navMeshData.indices[randomIndex]];
        Vector3 v2 = navMeshData.vertices[navMeshData.indices[randomIndex + 1]];
        Vector3 v3 = navMeshData.vertices[navMeshData.indices[randomIndex + 2]];

        Vector3 randomPoint = v1 + Random.value * (v2 - v1) + Random.value * (v3 - v1);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            randomPoint = hit.position;
        }
        else
        {
            // If the random point is not on the navmesh, try again
            return GetRandomPositionOnNavmesh(spawnedPositions);
        }

        if (!IsFarFromOtherObjects(randomPoint, spawnedPositions))
        {
            // If the random point is too close to other objects, try again
            return GetRandomPositionOnNavmesh(spawnedPositions);
        }

        return randomPoint;
    }

    private bool IsFarFromOtherObjects(Vector3 position, List<Vector3> spawnedPositions)
    {
        foreach (Vector3 spawnedPosition in spawnedPositions)
        {
            if (Vector3.Distance(position, spawnedPosition) < minDistanceBetweenObjects)
            {
                return false;
            }
        }
        return true;
    }

    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
