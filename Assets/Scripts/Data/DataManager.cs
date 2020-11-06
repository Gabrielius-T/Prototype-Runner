using UnityEngine;
using System;
using System.IO;

public class DataManager
{
    const string JSON_EXTENSION = "json";
    const string DATA_LOCATION = "Data";
	const float WWW_TIMEOUT = 1f;
	
	public static void SaveData(string _key, object _serializable)
	{
		string _dataPath = "";
		if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor) {
			_dataPath = Path.Combine(Application.streamingAssetsPath, string.Format("{0}/{1}.{2}", _serializable.GetType().Name, _key, JSON_EXTENSION));
		} else {
			string _dataFolder = Path.Combine(Application.persistentDataPath, DATA_LOCATION);
			if(!Directory.Exists(_dataFolder)) {
				Directory.CreateDirectory(_dataFolder);
			}
			
			string _dataTypeFolder = Path.Combine(_dataFolder, _serializable.GetType().Name);
			if(!Directory.Exists(_dataTypeFolder)) {
				Directory.CreateDirectory(_dataTypeFolder);
			}		
			
			_dataPath = Path.Combine(Application.persistentDataPath, string.Format("{0}/{1}/{2}.{3}", DATA_LOCATION, _serializable.GetType().Name, _key, JSON_EXTENSION));	
		}
		
		File.WriteAllText(_dataPath, JsonUtility.ToJson(_serializable));
	}	

	public static T LoadData<T>(string _key)
	{
		string _dataPath = Path.Combine(Application.persistentDataPath, string.Format("{0}/{1}/{2}.{3}", DATA_LOCATION, typeof(T).Name, _key, JSON_EXTENSION));

		string _data;
		if(File.Exists(_dataPath))
		{
			_data = File.ReadAllText(_dataPath); 
		}
		else
		{
			_data = TryLoadDefault(typeof(T).Name, _key);
			
			if(_data == "" || _data == null) {
				Debug.LogWarning(string.Format("DataManager.LoadData::Cannot load data for <{0}> from <{1}>!", _key, typeof(T).Name));
				return default(T);
			}
		}
		
		T _loadedData = JsonUtility.FromJson<T>(_data);
		return _loadedData;
	}
	
	public static string TryLoadDefault(string _type, string _key)
	{
		string _dataPath = Path.Combine(Application.streamingAssetsPath, string.Format("{0}/{1}.{2}", _type, _key, JSON_EXTENSION));
		if(File.Exists(_dataPath) || Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
			WWW _loader = new WWW(_dataPath);
				DateTime _timeEnd = DateTime.Now.AddSeconds(WWW_TIMEOUT);
				while(!_loader.isDone) {
					DateTime _timeNow = DateTime.Now;
					if(_timeNow >= _timeEnd) {
						Debug.LogError(string.Format("DataManager.TryLoadDefault::Unable to load default data for {0} of type {1}.", _key, _type));
						Application.Quit();
						return null;
					}
				}
				return _loader.text;
		}		
		return null;
	}
}