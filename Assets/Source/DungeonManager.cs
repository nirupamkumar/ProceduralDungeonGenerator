using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    public GameObject floorPrefab, wallPrefab, tileSpawnerPrefab, exitDoorPrefab;
    public int totalFloorCount;

    [HideInInspector] public float minX, maxX, minY, maxY;

    private List<Vector3> floorList = new List<Vector3>();

    private void Start()
    {
        RandomWalker();
    }

    private void Update()
    {
        // Optional to Test Dungeon Generation inEditor
        if (Application.isEditor && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void RandomWalker()
    {
        Vector3 currentPos = Vector3.zero;
        floorList.Add(currentPos);

        while (floorList.Count < totalFloorCount)
        {
            switch (Random.Range(1, 5))
            {
                case 1: currentPos += Vector3.up; break;
                case 2: currentPos += Vector3.right; break;
                case 3: currentPos += Vector3.down; break;
                case 4: currentPos += Vector3.left; break;
            }

            bool inFloorList = false;
            for (int i = 0; i < floorList.Count; i++)
            {
                if (Vector3.Equals(currentPos, floorList[i]))
                {
                    inFloorList = true;
                    break;
                }
            }

            if (!inFloorList)
            {
                floorList.Add(currentPos);
            }
        }

        for (int i = 0; i < floorList.Count; i++)
        {
            GameObject goTile = Instantiate(tileSpawnerPrefab, floorList[i], Quaternion.identity) as GameObject;
            goTile.name = tileSpawnerPrefab.name;
            goTile.transform.SetParent(transform);
        }

        StartCoroutine(DelayProgress());
    }

    IEnumerator DelayProgress()
    {
        while (FindObjectsOfType<TileSpawner>().Length > 0)
        {
            yield return null;
        }
        ExitDoor();
    }

    private void ExitDoor()
    {
        Vector3 doorPos = floorList[floorList.Count - 1];
        GameObject goExitDoor = Instantiate(exitDoorPrefab, doorPos, Quaternion.identity) as GameObject;
        goExitDoor.name = exitDoorPrefab.name;
        goExitDoor.transform.SetParent(transform);
    }
}
