using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AutoWrapTextMeshPro : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float maxWidth = 300f; // 最大宽度限制

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTextWidth()
    {
        string originalText = textMesh.text;  // 原始文本
        string result = "";  // 最终的文本结果
        string line = "";  // 当前行的文本

        for (int i = 0; i < originalText.Length; i++)
        {
            char currentChar = originalText[i];  // 当前字符
            string testLine = line + currentChar;  // 尝试添加当前字符到当前行

            // 计算测试行的宽度
            float testWidth = textMesh.GetPreferredValues(testLine).x;

            if (testWidth > maxWidth)
            {
                // 如果当前行加上新字符超出最大宽度，提交当前行到结果，并开始新行
                if (!string.IsNullOrEmpty(line))
                {
                    result += line + "\n";
                }
                line = currentChar.ToString();  // 当前字符开始新行
            }
            else
            {
                // 如果不超出最大宽度，将字符添加到当前行
                line += currentChar;
            }
        }

        // 添加最后一行到结果
        if (!string.IsNullOrEmpty(line))
        {
            result += line;
        }

        textMesh.text = result;  // 更新TextMeshPro组件的文本
    }


}
