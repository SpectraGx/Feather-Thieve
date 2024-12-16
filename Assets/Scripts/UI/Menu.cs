using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private Dictionary<GameObject, GameObject> panelFirstButtonMapping;
    private int controlsNum;
    private bool taptostart = false;

    [Header("Inspector: Panels")]
    [SerializeField] private GameObject titlePanel;
    [SerializeField] public GameObject mainMenu;

    [Header("Inspector: FadesController")]
    [SerializeField] private FadeController titleFade;


    [Header("Inspecor: FirstButton")]
    [SerializeField] private GameObject mainFirstButton;


    private void Awake()
    {
        titlePanel.SetActive(true);
        panelFirstButtonMapping = new Dictionary<GameObject, GameObject>(){
            {mainMenu, mainFirstButton},
        };
        taptostart = false;
    }

    private void Update()
    {
        if (taptostart == false)
        {
            if (Input.anyKeyDown)
            {
                OpenMainMenu();
            }
        }
    }

    public void Play(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void URL(string url)
    {
        Application.OpenURL(url);
    }

    public void OpenPanel(GameObject panelToOpen)
    {
        foreach (var panel in panelFirstButtonMapping.Keys)
        {
            panel.SetActive(false);
        }

        panelToOpen.SetActive(true);

        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            if (panelFirstButtonMapping.TryGetValue(panelToOpen, out GameObject firstButton))
            {
                EventSystem.current.SetSelectedGameObject(firstButton);
            }
        }
    }

    public void OpenMainMenu()
    {
        titleFade.FadeOut();
        //OpenPanel(mainMenu);
        taptostart = true;
        //titlePanel.SetActive(false);
    }


}
