using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySpace : MonoBehaviour
{
    float fieldWidth;
    float fieldHeight;
    float screenWidth;
    float screenHeight;

    // Start is called before the first frame update
    void Start()
    {
        fieldWidth = Mathf.RoundToInt(Random.Range(6f, 20f));
        fieldHeight = Mathf.RoundToInt(Random.Range(8f, 20f));

        transform.localScale = new Vector3(fieldWidth, 1, fieldHeight);
    }

    // Update is called once per frame
    void Update()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // Ádd some code here to make the field smaller if it doesn't normally fit on the screen comfortably
        while (fieldWidth > screenWidth * 0.8)
        {
            fieldWidth *= 0.95f;
            fieldHeight *= 0.95f;

            transform.localScale = new Vector3(fieldWidth, 1, fieldHeight);
        }
    }
}
