using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CellCountText : MonoBehaviour
{
    public string normalCellTag = "Cell";
    public string predatorCellTag = "CellEater";

    private TMP_Text countText;

    private void Start()
    {
        countText = GetComponent<TMP_Text>();
        UpdateCountText();
    }

    private void Update()
    {
        UpdateCountText();
    }

    private void UpdateCountText()
    {
        int normalCellCount = CountGameObjectsWithTag(normalCellTag);
        int predatorCellCount = CountGameObjectsWithTag(predatorCellTag);

        countText.text = "Normal Cells: " + normalCellCount.ToString() + "\n"
            + "Predator Cells: " + predatorCellCount.ToString();
    }

    private int CountGameObjectsWithTag(string tag)
    {
        GameObject[] cells = GameObject.FindGameObjectsWithTag(tag);
        return cells.Length;
    }
}
