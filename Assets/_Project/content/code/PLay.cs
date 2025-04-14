using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PLay : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main Game");
    }
    public void Quit()
    {
        Application.Quit();
    }

    [UnityEditor.MenuItem("Masa/Fix Tiles")]
    static void Fix()
    {
        GameObject[] allObjects = Object.FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID);

        List<GameObject> allTiles = allObjects.Where(o => o.name.Contains("Floor_01") && o.GetComponent<Renderer>() != null).ToList();
        Debug.Log(allTiles.Count);

        foreach (GameObject tile in allTiles)
        {
            UnityEditor.Undo.RecordObject(tile.transform, "Fix Tiles");
            Vector3 pos = tile.transform.position;

            pos.x = (int)(pos.x / 3f) * 3;
            pos.z = (int)(pos.z / 3f) * 3;

            tile.transform.position = pos;
        }

        Debug.Log("Tiles fixed!");
    }
}
