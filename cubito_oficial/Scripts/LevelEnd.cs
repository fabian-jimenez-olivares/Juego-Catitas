using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private String nextLevel;

    [SerializeField] private Image[] imageList;
    [SerializeField] private float delay; 

    [SerializeField] private ColorPalette[] colorPalettes;

    private void Awake() => AssignColor();

    private void Start() => ColorController.InputEnabled = true;

    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(LoadNextScene(nextLevel));
        Destroy(other.gameObject);
    }

    private IEnumerator LoadNextScene(String levelName)
    {
        AssignColor();
        ColorController.InputEnabled = false;
        int c = 0;
        foreach (Image image in imageList)
        {
            image.GetComponent<Animator>().SetTrigger("Start");
            c++;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(delay);
        
        SceneManager.LoadScene(levelName);
    }

    private void AssignColor()
    {
        int c = 0;
        
        foreach (Image image in imageList)
        {
            image.color = colorPalettes[ColorController.CurrentColor - 1].colors[c].color;
            c++;
        }
    }
    
    public void Die() => StartCoroutine(LoadNextScene(SceneManager.GetActiveScene().name));
}
