using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BottomTextScript : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        GameEvents.Current.OnColorSwapTrigger += ColorSwap;
        
        _text = GetComponent<Text>();
        _text.enabled = false;
    }

    private void OnDisable() => GameEvents.Current.OnColorSwapTrigger -= ColorSwap;

    private void ColorSwap(int id)
    {
        StopAllCoroutines();
        StartCoroutine(TextUpdate(id));
    }

    private IEnumerator TextUpdate(int id)
    {
        if (id == c.Monocromia.ID)
            _text.text = c.Monocromia.Name;
        else if (id == c.Protonopia.ID)
            _text.text = c.Protonopia.Name;
        else if (id == c.Tritonopia.ID)
            _text.text = c.Tritonopia.Name;

        _text.enabled = true;
        yield return new WaitForSeconds(2);
        _text.enabled = false;
    }
}
