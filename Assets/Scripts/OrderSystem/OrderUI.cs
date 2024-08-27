using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text client;
    public TMP_Text desc;
    public TMP_Text dueTo;
    public TMP_Text reward;
    public TMP_Text fine;
    public RectTransform _title;
    public RectTransform _desc;
    public Canvas canvas;
    public Image portrait;

    public void SetOrderPanel(Order order) {
        title.text = order.id;
        client.text = "Od: " + order.clientName;
        portrait.sprite = order.clientIcon;
        string orderText = "";
        foreach (OrderEntry a in order.orders) {
            orderText += " - " + a.item.itemName + " x" + a.quantity + "\n";
        }
        desc.text = orderText;
        dueTo.text = order.dueTo;
        string rewardText = "";
        if (order.moneyReward != 0) rewardText += order.moneyReward + "zł ";
        if (order.expReward != 0) rewardText += order.expReward + "EXP";
        if (rewardText != "") reward.text = "Nagroda: " + rewardText;
        string fineText = "";
        if (order.moneyFine != 0) fineText += order.moneyFine + "zł ";
        if (order.expFine != 0) fineText += order.expFine + "EXP";
        if (fineText != "") fine.text = "Kara: " + fineText;
        
        
        // Canvas.ForceUpdateCanvases();
        // //_title.sizeDelta =
        //     new Vector2(title.GetComponent<RectTransform>().sizeDelta.x, 0.15f * title.textInfo.lineCount);
        // _desc.sizeDelta =
        //     new Vector2(desc.GetComponent<RectTransform>().sizeDelta.x, 0.15f * desc.textInfo.lineCount);
        // Canvas.ForceUpdateCanvases();
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
