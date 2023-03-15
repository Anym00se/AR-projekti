using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject top1;
    private GameObject top2;
    [SerializeField] private GameObject topPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SpawnTop()
    {
        GameObject arena = FindArena();
        if (arena)
        {
            if (!top1)
            {
                top1 = Instantiate(topPrefab, arena.transform.Find("Spawn1").position, Quaternion.identity);
                top1.GetComponent<Rigidbody>().useGravity = false;
            }
            else if (!top2)
            {
                top2 = Instantiate(topPrefab, arena.transform.Find("Spawn2").position, Quaternion.identity);
                top2.GetComponent<Rigidbody>().useGravity = false;
            }
        }
    }

    public void ReleaseTops()
    {
        if (top1)
        {
            top1.GetComponent<Rigidbody>().useGravity = true;
        }
        if (top2)
        {
            top2.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    GameObject FindArena()
    {
        return GameObject.FindWithTag("Arena");
    }
}
