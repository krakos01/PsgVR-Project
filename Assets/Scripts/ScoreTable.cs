using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<ScoreboardEntry> scoreboardEntryList;
    private List<Transform> scoreboardEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("ScoreEntryContainer");
        entryTemplate = entryContainer.Find("ScoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);


        // Initialize lists
        scoreboardEntryTransformList = new List<Transform>();
        scoreboardEntryList = new List<ScoreboardEntry>();

        // Check if saved data exists
        if (PlayerPrefs.HasKey("scoreTable"))
        {
            string jsonString = PlayerPrefs.GetString("scoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


            
            // Check if data is deserialized
            if (highscores != null && highscores.entryList != null)
            {
                scoreboardEntryList = highscores.entryList;

                // Sort by 'score'
                scoreboardEntryList.Sort((entry1, entry2) => entry2.score.CompareTo(entry1.score));
            }
        }


        foreach (ScoreboardEntry entry in scoreboardEntryList)
        {
            CreateScoreboardEntryTransform(entry, entryContainer, scoreboardEntryTransformList);
        }

    }


    private void CreateScoreboardEntryTransform(ScoreboardEntry entry, Transform containter, List<Transform> transformList)
    {
        float templateHeight = 40f;
        int rank = transformList.Count + 1;
        Transform entryTransform = Instantiate(entryTemplate, containter);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector3(0, -templateHeight * rank);
        entryTransform.gameObject.SetActive(true);


        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("PositionText").GetComponent<TextMeshProUGUI>().text = rankString;
        entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = entry.score.ToString();

        // Enable / disable background for the score
        entryTransform.Find("Background").gameObject.SetActive(rank % 2 == 1);

        // Highlight first
        if (rank == 1)
        {
            entryTransform.Find("PositionText").GetComponent<TextMeshProUGUI>().color = new Color(1f, 0.843f, 0f);  // Gold color
            entryTransform.Find("PositionText").GetComponent<TextMeshProUGUI>().fontWeight = FontWeight.Bold;
            
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().color = new Color(1f, 0.843f, 0f);
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().fontWeight = FontWeight.Bold; 
        }

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score)
    {
        // Create ScoreboardEntry
        ScoreboardEntry entry = new ScoreboardEntry { score = score };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("scoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Add new entry
        highscores.entryList.Add(entry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("scoreTable", json);
        PlayerPrefs.Save();

    }

    private class Highscores 
    { 
        public List<ScoreboardEntry> entryList;
    }

    /// <summary>
    /// Represents a single high score entry
    /// </summary>
    [Serializable]
    private class ScoreboardEntry
    {
        public int score;
    }
}
