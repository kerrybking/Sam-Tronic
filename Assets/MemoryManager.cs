using UnityEngine;

public class MemoryManager : MonoBehaviour
{
    public void CleanUpMemory()
    {
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
}
