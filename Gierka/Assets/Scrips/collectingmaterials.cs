using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class collectingmaterials : MonoBehaviour
{
    public int woods = 0;
    public int sticks = 0;
    public int leafs = 0;
    public TextMeshProUGUI textMesh1;
    public TextMeshProUGUI textMesh2;
    public TextMeshProUGUI textMesh3;
    int score;

    public void collectingwoods()
    {
        woods += 5;
        sticks += 8;
        leafs += 10;
        textMesh1.text = woods.ToString();
        textMesh2.text = sticks.ToString();
        textMesh3.text = leafs.ToString();

    }
}
