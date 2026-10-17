using UnityEngine;
public static class PortfolioBrowserFont
{
    static Font font;
    public static void Apply(params GUIStyle[] styles)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (font == null) font = Resources.Load<Font>("Portfolio/Fonts/NotoSansSC-Regular");
        GUI.skin.font = font;
        foreach (var style in styles) if (style != null) style.font = font;
#endif
    }
}
