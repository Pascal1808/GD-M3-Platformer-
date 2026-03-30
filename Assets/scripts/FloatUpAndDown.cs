using Unity.Mathematics;
using UnityEngine;

public class FloatUpAndDown : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    
    void Update()
    {
        float yOffset = math.sin(Time.time * frequency) * amplitude;
        transform.localPosition = new Vector3(startPos.x, startPos.y + yOffset, startPos.z);
    }
}
