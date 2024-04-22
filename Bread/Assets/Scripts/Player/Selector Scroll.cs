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
            scrollUp();
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            scrollDown();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = false;
            currentSelector = 0;
            transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = false;
            currentSelector = 1;
            transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = false;
            currentSelector = 2;
            transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = false;
            currentSelector = 3;
            transform.GetChild(currentSelector).gameObject.GetComponent<Image>().enabled = true;
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