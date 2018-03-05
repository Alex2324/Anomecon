using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameMenuUI : MonoBehaviour {

    public GameObject exitMenuUI;
    public GameObject exitJournalUI;

    // Use this for initialization
    void Start () { }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ExitMenu"))
        {
            exitMenuUI.SetActive(!exitMenuUI.activeSelf);
        }
        if (Input.GetButtonDown("ExitJournal"))
        {
            exitJournalUI.SetActive(!exitJournalUI.activeSelf);
        }
	}
    public void Yes() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void No() {
        exitMenuUI.SetActive(!exitMenuUI.activeSelf);
    }
}
