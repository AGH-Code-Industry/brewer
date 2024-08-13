using System.Collections;
using System.Collections.Generic;
using CoinPackage.Debugging;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour {
    public TMP_Text title;
    public TMP_Text desc;
    public RectTransform _title;
    public RectTransform _desc;
    public Canvas canvas;

    public void SetTaskButton(string name, string status) {
        title.text = name;
        desc.text = status;
        Canvas.ForceUpdateCanvases();
        _title.sizeDelta =
            new Vector2(title.GetComponent<RectTransform>().sizeDelta.x, 0.15f * title.textInfo.lineCount);
        _desc.sizeDelta =
            new Vector2(desc.GetComponent<RectTransform>().sizeDelta.x, 0.15f * desc.textInfo.lineCount);
        Canvas.ForceUpdateCanvases();
        RefreshLayout();
    }
    private void RefreshLayout()
    {
        transform.GetComponent<VerticalLayoutGroup>().enabled = false;
        transform.GetComponent<VerticalLayoutGroup>().enabled = true;
        for (var i = 0; i < transform.childCount; i++)
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform.GetChild(i).GetComponent<RectTransform>());
    }
    
}
