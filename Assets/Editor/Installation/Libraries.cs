using UnityEditor;
using UnityEditor.PackageManager;


public class Libraries
{
    [MenuItem("Base infrastructure/Libraries/Add Zenject")]
    public static void AddZenject()
    {
        Client.Add("https://github.com/Mathijs-Bakker/Extenject.git?path=UnityProject/Assets/Plugins/Zenject/Source");
    }
}