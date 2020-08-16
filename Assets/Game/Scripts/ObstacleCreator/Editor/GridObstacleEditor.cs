using UnityEditor;

namespace ColorBump
{
    [CustomEditor(typeof(GridObstacle))]
    public class GridObstacleEditor : GridEnumEditor<ObjectType>
    {
        protected override int CellWidth { get { return 70; } }

        protected override int CellHeight { get { return 16; } }

        protected override void OnEndInspectorGUI()
        {
            EditorGUILayout.Space();

            var objectType = serializedObject.FindProperty("objectType");
            var obstacleType = serializedObject.FindProperty("obstacleType");
            EditorGUILayout.PropertyField(objectType);
            EditorGUILayout.PropertyField(obstacleType);
        }
    }
}