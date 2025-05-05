using UnityEngine;

[System.Serializable]
public class EventData
{
    public string prompt;
    public string[] options = new string[3];
    public int[] repChange_Friendly = new int[3];
    public int[] repChange_Cold = new int[3];
    public int[] repChange_Manip = new int[3];
    public int[] suspChange_Friendly = new int[3];
    public int[] suspChange_Cold = new int[3];
    public int[] suspChange_Manip = new int[3];

    public int GetRepChange(int maskIndex, int optionIndex)
    {
        return maskIndex switch
        {
            0 => repChange_Friendly[optionIndex],
            1 => repChange_Cold[optionIndex],
            2 => repChange_Manip[optionIndex],
            _ => 0
        };
    }

    public int GetSuspChange(int maskIndex, int optionIndex)
    {
        return maskIndex switch
        {
            0 => suspChange_Friendly[optionIndex],
            1 => suspChange_Cold[optionIndex],
            2 => suspChange_Manip[optionIndex],
            _ => 0
        };
    }
}
