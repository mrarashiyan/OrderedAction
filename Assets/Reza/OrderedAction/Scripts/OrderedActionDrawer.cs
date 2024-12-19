using Reza.OrderedAction.Scripts;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(OrderedAction))]
public class OrderedActionDrawer : PropertyDrawer
{
    private bool isExpanded = false;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty queueProperty = property.FindPropertyRelative("m_Queue");
        if (queueProperty == null || !isExpanded)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        // Header row + number of elements + spacing
        return EditorGUIUtility.singleLineHeight * (queueProperty.arraySize + 2);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty queueProperty = property.FindPropertyRelative("m_Queue");
        if (queueProperty == null)
        {
            EditorGUI.LabelField(position, label.text, "Property not found.");
            return;
        }

        // Draw the foldout header
        Rect foldoutRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        isExpanded = EditorGUI.Foldout(foldoutRect, isExpanded, label);

        if (!isExpanded) return;

        // Draw column headers
        EditorGUI.indentLevel++;
        Rect headerRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);
        DrawRow(headerRect, "Order", "Title", header: true);

        // Draw each row
        for (int i = 0; i < queueProperty.arraySize; i++)
        {
            SerializedProperty singleActionProperty = queueProperty.GetArrayElementAtIndex(i);
            SerializedProperty titleProperty = singleActionProperty.FindPropertyRelative("title");
            SerializedProperty orderProperty = singleActionProperty.FindPropertyRelative("order");

            string title = string.IsNullOrEmpty(titleProperty.stringValue) ? "No Title" : titleProperty.stringValue;
            int order = orderProperty.intValue;

            Rect rowRect = new Rect(position.x, position.y + (i + 2) * EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);
            DrawRow(rowRect, order.ToString(), title, i % 2 == 0);
        }
        EditorGUI.indentLevel--;
    }

    private void DrawRow(Rect rect, string order, string title, bool alternateColor = false, bool header = false)
    {
        Color originalColor = GUI.backgroundColor;

        // Set row color
        if (header)
            GUI.backgroundColor = new Color(0.6f, 0.6f, 0.6f,0.1f); // Gray for headers
        else if (alternateColor)
            GUI.backgroundColor = new Color(0.9f, 0.9f, 0.9f,0.2f); // Light gray for alternating rows
        else
            GUI.backgroundColor = new Color(0.9f, 0.9f, 0.9f,0.1f); // White for default rows

        // Draw background
        EditorGUI.DrawRect(rect, GUI.backgroundColor);

        // Restore original color
        GUI.backgroundColor = originalColor;

        // Define column widths
        float columnWidth = rect.width / 5;

        // Draw columns
        Rect orderRect = new Rect(rect.x, rect.y, columnWidth, rect.height);
        Rect titleRect = new Rect(rect.x + columnWidth, rect.y, columnWidth * 5, rect.height);

        // Center-align text for headers, left-align otherwise
        if (header)
        {
            EditorGUI.LabelField(orderRect, order, EditorStyles.boldLabel);
            EditorGUI.LabelField(titleRect, title, EditorStyles.boldLabel);
        }
        else
        {
            EditorGUI.LabelField(orderRect, order);
            EditorGUI.LabelField(titleRect, title);
        }
    }
}
