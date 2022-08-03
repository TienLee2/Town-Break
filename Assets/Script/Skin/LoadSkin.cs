using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSkin : MonoBehaviour
{
    public Transform turret, hat, glove, shirt;

    void Start()
    {
        LoadPart();
        LoadPart2();
        LoadPart3();
        LoadPart4();
    }
    

    private void LoadPart()
    {
        // Cycle between all rocket parts.
        foreach (Transform part in turret)
        {
            
                // Get value if rocket part is added.
                bool partAdded = PlayerPrefs.GetInt("PartAdded-1" + part.name, 0) == 1 ? true : false;
                // Set rocket part gameobject state to active or disabled according to partAdded value.
                part.gameObject.SetActive(partAdded);
            
        }
    }
    private void LoadPart2()
    {
        // Cycle between all rocket parts.
        foreach (Transform part in hat)
        {
                // Get value if rocket part is added.
                bool partAdded = PlayerPrefs.GetInt("PartAdded-2" + part.name, 0) == 1 ? true : false;
                // Set rocket part gameobject state to active or disabled according to partAdded value.
                part.gameObject.SetActive(partAdded);
            
        }
    }
    private void LoadPart3()
    {
        // Cycle between all rocket parts.
        foreach (Transform part in glove)
        {
                // Get value if rocket part is added.
                bool partAdded = PlayerPrefs.GetInt("PartAdded-3" + part.name, 0) == 1 ? true : false;
                // Set rocket part gameobject state to active or disabled according to partAdded value.
                part.gameObject.SetActive(partAdded);
            
        }
    }
    private void LoadPart4()
    {
        // Cycle between all rocket parts.
        foreach (Transform part in shirt)
        {
                // Get value if rocket part is added.
                bool partAdded = PlayerPrefs.GetInt("PartAdded-4" + part.name, 0) == 1 ? true : false;
                // Set rocket part gameobject state to active or disabled according to partAdded value.
                part.gameObject.SetActive(partAdded);
            
        }
    }
}
