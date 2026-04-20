using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    public static RecordManager Instance;

    private List<Record> records = new List<Record>();

    void Awake()
    {
        // 🔥 Singleton safety (prevents duplicates)
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void AddRecord(string name, int level, float time)
    {
        records.Add(new Record(name, level, time));

        // 🔥 Sort: level high → time low
        records.Sort((a, b) =>
        {
            if (b.level != a.level)
                return b.level.CompareTo(a.level);

            return a.time.CompareTo(b.time);
        });

        if (records.Count > 10)
            records.RemoveRange(10, records.Count - 10);
    }

    public List<Record> GetRecords()
    {
        return records;
    }
}