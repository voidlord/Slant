using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    public GameManager gameManager;

    static GameObject[] platformPrefabs;
    List<GameObject> spawnedPlatforms;

    const int maxSpawn = 20;

    int yOffset = 0;
    int zOffset = 0;

    bool passedFirst = false;

	void Awake() {
        if (platformPrefabs == null) {
            platformPrefabs = Resources.LoadAll<GameObject>("Prefabs");

            if (platformPrefabs.Length == 0) {
                Debug.LogError("No Prefabs found.\nIncase you deleted them, have fun in the void");
            }
        }
	}

	void Start() {
        spawnedPlatforms = new List<GameObject>();

        GameObject start = null;

        for (int i = 0; i < platformPrefabs.Length; i++) {
            if (platformPrefabs[i].name == "Simple") {
                start = platformPrefabs[i];
                break;
			}
		}

        if (start) {
            SpawnPlatform(start);
		} else {
            SpawnPlatform(platformPrefabs[0]);
        }
    }

    void FixedUpdate() {
        while ((!gameManager.GameHasEnded) && (spawnedPlatforms.Count < maxSpawn)) {
            int x = Random.Range(0, platformPrefabs.Length);
            SpawnPlatform(platformPrefabs[x]);
		}
    }

    public void SpawnPlatform(GameObject platform) {
        GameObject gameObject;

        gameObject = Instantiate<GameObject>(platform);

        gameObject.transform.SetParent(transform);
        gameObject.transform.Translate(0, yOffset, zOffset);

        yOffset -= gameObject.GetComponent<Platform>().yOffset;
        zOffset += gameObject.GetComponent<Platform>().zOffset;

        spawnedPlatforms.Add(gameObject);
    }

    public List<GameObject> GetSpawnedPlatformsList() {
        return spawnedPlatforms;
	}

    public void ClearFirstPlatform() {
        if (!passedFirst) {
            passedFirst = true;
		} else {
            Destroy(spawnedPlatforms[0]);
            spawnedPlatforms.RemoveAt(0);
		}
	}
}
