using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menuing : MonoBehaviour
{
    [SerializeField] private GameObject[] menuScreens;
    [SerializeField] private int openMenu;
    [SerializeField] private int closeMenu;

    [SerializeField] private Button button;

    //private void Start()
    //{
    //    for (int i = 1; i < menuScreens.Length; i++)
    //    {
    //        menuScreens[i].SetActive(false);
    //    }
    //}

    public void StartGame()
    {
        SceneManager.LoadScene("Lab Stage (testing)");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Title Menu");
    }

    public void OpenScreen()
    {
        menuScreens[closeMenu].SetActive(false);
        menuScreens[openMenu].SetActive(true);
    }

    public void GoBack()
    {
        menuScreens[openMenu].SetActive(false);
        menuScreens[closeMenu].SetActive(true);
    }
}
