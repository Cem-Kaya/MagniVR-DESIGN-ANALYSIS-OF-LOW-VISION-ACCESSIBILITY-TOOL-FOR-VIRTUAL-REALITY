using System.IO;
using UnityEngine;

public class File_manager{

	private static File_manager file_manager_singolton = null;
	private string fileName;
	private File_manager ( ){
		// name the file from the date and time 
		fileName = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";

	}
	public static File_manager get_singelton()
	{
		if(file_manager_singolton == null)
		{
			file_manager_singolton = new File_manager();
		}
		return file_manager_singolton;
	}

	private string GetFilePath()
	{
		string path;

		if (Application.platform == RuntimePlatform.WindowsEditor ||Application.platform == RuntimePlatform.WindowsPlayer)
		{
			path = Path.Combine(Application.dataPath, fileName);
		}
		else if (Application.platform == RuntimePlatform.Android)
		{
			path = Path.Combine(Application.persistentDataPath, fileName);
		}
		else
		{
			throw new System.NotSupportedException("Platform not supported for file management.");
		}

		return path;
	}


	public void WriteToFile(string content)
	{
		string filePath = GetFilePath();

		try
		{
			File.WriteAllText(filePath, content + "\n" );
			//Debug.Log("File written successfully at: " + filePath);
		}
		catch (System.Exception e)
		{
			Debug.LogError("Error writing to file: " + e.Message);
		}
	}



}
