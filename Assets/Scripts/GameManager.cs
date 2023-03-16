using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject top1;
    private GameObject top2;
    [SerializeField] private GameObject topPrefab;

    [Header("UI")]
    [SerializeField] private Slider top1SizeSlider;
    [SerializeField] private Slider top2SizeSlider;
    [SerializeField] private GameObject top1Wrapper;
    [SerializeField] private GameObject top2Wrapper;
    [SerializeField] private Button releaseTopsButton;
    [SerializeField] private Button spawnNewTopsButton;
    [SerializeField] private Text winnerText;
    private bool gameStarted = false;

    void Start()
    {
        winnerText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            ReloadScene();
        }

        top1Wrapper.SetActive(top1 != null);
        top2Wrapper.SetActive(top2 != null);

        releaseTopsButton.interactable = top1 != null && top2 != null;
        spawnNewTopsButton.interactable = top1 == null || top2 == null;

        if (gameStarted)
        {
            string whoWins = "";
            if (!top1)
            {
                gameStarted = false;
                whoWins = "Top 2 wins!";
                Debug.Log(whoWins);
            }
            if (!top2)
            {
                gameStarted = false;
                whoWins = "Top 1 wins!";
                Debug.Log(whoWins);
            }

            // Case: Game ended because a top has been destoryed
            if (!gameStarted)
            {
                if (top1) { Destroy(top1, 2f); }
                if (top2) { Destroy(top2, 2f); }

                ShowWinnerText(whoWins);
            }
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SpawnTop()
    {
        winnerText.gameObject.SetActive(false);

        GameObject arena = FindArena();
        if (arena)
        {
            if (!top1)
            {
                top1 = Instantiate(topPrefab, arena.transform.Find("Spawn1").position, Quaternion.identity);
                DisableTop(top1);
                ChangeTopColor(top1);
            }
            else if (!top2)
            {
                top2 = Instantiate(topPrefab, arena.transform.Find("Spawn2").position, Quaternion.identity);
                DisableTop(top2);
                ChangeTopColor(top2);
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

        gameStarted = true;
    }

    GameObject FindArena()
    {
        return GameObject.FindWithTag("Arena");
    }

    private void EnableTop(GameObject top)
    {
        top.GetComponent<Rigidbody>().useGravity = true;
        top.transform.Find("MeshWrapper").GetComponent<Top>().enabled = true;
    }

    private void DisableTop(GameObject top)
    {
        top.GetComponent<Rigidbody>().useGravity = false;
        top.transform.Find("MeshWrapper").GetComponent<Top>().enabled = false;
        top.transform.rotation = Quaternion.identity;
    }

    public void ChangeTop_1_Size()
    {
        if (top1)
        {
            ChangeTopSize(top1, top1SizeSlider);
        }
    }

    public void ToggleTop_1_Color()
    {
        if (top1)
        {
            ChangeTopColor(top1);
        }
    }

    public void ChangeTop_2_Size()
    {
        if (top2)
        {
            ChangeTopSize(top2, top2SizeSlider);
        }
    }

    public void ToggleTop_2_Color()
    {
        if (top2)
        {
            ChangeTopColor(top2);
        }
    }

    private void ChangeTopSize(GameObject top, Slider slider)
    {
        top.transform.localScale = Vector3.one * slider.value;
        top.GetComponent<Rigidbody>().mass = slider.value * slider.value;
    }

    private void ChangeTopColor(GameObject top)
    {
        Renderer topMeshRenderer = top.transform.Find("MeshWrapper").Find("top").GetComponent<Renderer>();
        if (topMeshRenderer.materials[1].color == Color.blue)
        {
            topMeshRenderer.materials[1].color = Color.red;
        }
        else
        {
            topMeshRenderer.materials[1].color = Color.blue;
        }
    }

    private void ShowWinnerText(string winString)
    {
        winnerText.text = winString;
        winnerText.gameObject.SetActive(true);
    }
}
