using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject[] floorPanels;      // 0 = Floor1Panel, 1 = Floor2Panel, etc.
    public AudioClip[] floorClips;        // 0 = Floor1Voice, 1 = Floor2Voice, etc.
    public AudioSource audioSource;

    void Start()
    {
        // Hide all floor panels
        foreach (var panel in floorPanels)
            panel.SetActive(false);

        // Show only the main menu
        mainPanel.SetActive(true);
    }

    public void ShowFloorPanel(int index)
    {
        mainPanel.SetActive(false);
        for (int i = 0; i < floorPanels.Length; i++)
        {
            floorPanels[i].SetActive(i == index);
        }

        audioSource.clip = floorClips[index];
        audioSource.Play();
    }

    public void BackToMainMenu()
    {
        foreach (var panel in floorPanels)
            panel.SetActive(false);

        audioSource.Stop();
        mainPanel.SetActive(true);
    }
}
