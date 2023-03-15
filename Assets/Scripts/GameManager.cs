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
                DisableTop(top1);
            }
            else if (!top2)
            {
                top2 = Instantiate(topPrefab, arena.transform.Find("Spawn2").position, Quaternion.identity);
                DisableTop(top1);
            }
        }
    }

    public void ReleaseTops()
    {
        if (top1)
        {
            EnableTop(top1);
        }
        if (top2)
        {
            EnableTop(top2);
        }
    }

    GameObject FindArena()
    {
        return GameObject.FindWithTag("Arena");
    }

    private void EnableTop(GameObject top)
    {
        top.GetComponent<Rigidbody>().useGravity = true;
        top.transform.Find("TopWrapper").GetComponent<Top>().enabled = true;
    }

    private void DisableTop(GameObject top)
    {
        top.GetComponent<Rigidbody>().useGravity = false;
        top.transform.Find("TopWrapper").GetComponent<Top>().enabled = false;
        top.transform.rotation = Quaternion.identity;
    }
}
