using UnityEngine;

public static class JDebug
{
    public static void Log(string p_content, params object[] p_parameters)
    {
        Debug.LogFormat(p_content, p_parameters);
    }
}
