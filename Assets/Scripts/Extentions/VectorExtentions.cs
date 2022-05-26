using UnityEngine;

namespace Extentions
{
    public static class VectorExtentions
    {
        public static Vector3Int ToVector3Int(this Vector3 vector)
        {
            return new Vector3Int(Mathf.RoundToInt(vector.x), 
                Mathf.RoundToInt(vector.y), Mathf.RoundToInt(vector.z));
        }
    }
}