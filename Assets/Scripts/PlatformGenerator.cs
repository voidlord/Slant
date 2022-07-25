using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    public GameManager gameManager;

    static GameObject[] platformPrefabs;
    List<GameObject> spawnedPlatforms;

    public int maxSpawn = 20;
    public float distanceBetween = 1;
    public float distanceFall = 2;

    float xOffset = 0;
    float yOffset = 0;
    float zOffset = 0;

    int lastPlatform = -1;

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
    }

    void FixedUpdate() {
        while ((gameManager.GameState == GameState.Playing) && (spawnedPlatforms.Count < maxSpawn)) {
            int x = 0;

            // Make sure the first platform is always the one tagged with "Start"
            if (lastPlatform == -1) {
                for (int i = 0; i < platformPrefabs.Length; i++) {
                    if (platformPrefabs[i].tag == "Start") {
                        x = i;
                        break;
                    }
                }
            } else { // Otherwise spawn a random one, unless there is only one platform existing
                if (platformPrefabs.Length > 1) {
                    x = Random.Range(0, platformPrefabs.Length);
                    while (x == lastPlatform) {
                        x = Random.Range(0, platformPrefabs.Length);
                    }
                }
            }

            SpawnPlatform(platformPrefabs[x]);
            lastPlatform = x;
		}
    }

    public void SpawnPlatform(GameObject platform) {
        GameObject gameObject;

        gameObject = Instantiate<GameObject>(platform);

        gameObject.transform.SetParent(transform);
        gameObject.transform.Translate(xOffset, yOffset, zOffset + gameObject.GetComponent<Platform>().zOffset / 2);

        xOffset += gameObject.GetComponent<Platform>().xOffset;
        yOffset += gameObject.GetComponent<Platform>().yOffset - distanceFall;
        zOffset += gameObject.GetComponent<Platform>().zOffset + distanceBetween;

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

    public void ClearPlatforms() {
        for (int i = 0; i < spawnedPlatforms.Count; i++) {
            Destroy(spawnedPlatforms[i]);
		}

        spawnedPlatforms.Clear();

        xOffset = 0;
        yOffset = 0;
        zOffset = 0;

        lastPlatform = -1;
	}
}
