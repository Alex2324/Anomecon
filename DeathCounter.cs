using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCounter : MonoBehaviour {
     public GameObject congrats;

    // Use this for initialization
    void Start () {
        GameObject congrats = GameObject.Find("Congratulations Screen");
        foreach (Transform child in congrats.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    
    // Update is called once per frame
    void Update () {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {

            GameObject congrats = GameObject.Find("Congratulations Screen");
            foreach (Transform child in congrats.transform)
            {
                child.gameObject.SetActive(true);
            }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
