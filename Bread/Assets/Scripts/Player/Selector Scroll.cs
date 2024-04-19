using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorScroll : MonoBehaviour
{
    public int currentSelector = 0;
    int counter = 0;
    private void Update()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            counter++;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            counter--;
        }
        if(counter > 2)
        {
            scrollUp();
            counter = 0;
        }
        if(counter < -2)
        {
            scrollDown();
            counter = 0;
        }
    }

    private void scrollUp()
    {
        transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = false;
        if(currentSelector == 3)
        {
            currentSelector = 0;
        }
        else { currentSelector++; }
        transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = true;
    }
    private void scrollDown()
    {
        transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = false;
        if (currentSelector == 0)
        {
            currentSelector = 3;
        }
        else { currentSelector--; }
        transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = true;
    }
}
