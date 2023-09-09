using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSizeItem : MonoBehaviour
{
    public GridLayoutGroup gridLayout;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            FiveInven();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            TenInven();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TwentyInven();
        }
    }

    private void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        FiveInven();
        //TenInven();
    }

    public void FiveInven()
    {
        Vector2 newSize = new Vector2(198.2f, 210f);
        gridLayout.cellSize = newSize;
        Vector2 newSpacing = new Vector2(44.1f, 525f);
        gridLayout.spacing = newSpacing;

        gridLayout.padding.left = 50;
        gridLayout.padding.right = 10;
        gridLayout.padding.top = 35;
        gridLayout.padding.bottom = 460;
    }

    public void TenInven()
    {
        Vector2 newSize = new Vector2(223.1f, 227.2f);
        gridLayout.cellSize = newSize;
        Vector2 newSpacing = new Vector2(21.93f, 191.6f);
        gridLayout.spacing = newSpacing;
        /*
        gridLayout.padding.left = 50;
        gridLayout.padding.right = 10;
        gridLayout.padding.top = 220;
        gridLayout.padding.bottom = 220;
        */
    }

    public void TwentyInven()
    {
        Vector2 newSize = new Vector2(228.23f, 126.1f);
        gridLayout.cellSize = newSize;
        Vector2 newSpacing = new Vector2(13.8f, 55.45f);
        gridLayout.spacing = newSpacing;
        /*
        gridLayout.padding.left = 50;
        gridLayout.padding.right = 10;
        gridLayout.padding.top = 220;
        gridLayout.padding.bottom = 220;
        */
    }

}
