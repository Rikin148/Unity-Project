using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordUI : MonoBehaviour
{
    public TextMeshProUGUI recordText;

    public void ShowRecords()
    {
        List<Record> records = RecordManager.Instance.GetRecords();

        if (records.Count == 0)
        {
            recordText.text = "No Records Yet";
            return;
        }

        string display = "";

        for (int i = 0; i < records.Count; i++)
        {
            int minutes = Mathf.FloorToInt(records[i].time / 60);
            int seconds = Mathf.FloorToInt(records[i].time % 60);

            display += $"{i + 1}. {records[i].playerName} | Lvl {records[i].level} | {minutes:00}:{seconds:00}\n";
        }

        recordText.text = display;
    }
}