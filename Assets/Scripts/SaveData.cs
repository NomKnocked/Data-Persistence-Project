using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Web;
using UnityEngine.SocialPlatforms.Impl;

public class SaveData : MonoBehaviour
{
    

     [System.Serializable]
    public class HsPlayerData
    {
        public string highScoreName;
        public int highScorePoints;
    }

    

    public void SavePlayerData()
    {
        HsPlayerData myplayer = new HsPlayerData();
        myplayer.highScoreName = MainManager.highScoreName; 
        myplayer.highScorePoints = MainManager.highScorePoints;
        string json = JsonUtility.ToJson(myplayer);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath + "/savefile.json");
    }
   public void LoadPlayerData()
    {
        Debug.Log("IM HIM");
        string path = Application. persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HsPlayerData myplayer = JsonUtility.FromJson<HsPlayerData>(json);
            Debug.Log(myplayer);
            MainManager.highScoreName = myplayer.highScoreName;
            MainManager.highScorePoints = myplayer.highScorePoints;
            Debug.Log(Application.dataPath + "/savefile.json");

        }
    }
}
