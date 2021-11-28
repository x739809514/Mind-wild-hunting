using UnityEngine;

public class FloatingObj : MonoBehaviour
{
    public Vector3 offset;
    public float frequency;
    public bool playAwake;

    private Vector3 originPosition;
    private float tick;
    private float amplitude;
    private bool animate;

    void Awake()
    {
        // 如果没有设置频率或者设置的频率为0则自动记录成1
        if (Mathf.Approximately(frequency, 0))
            frequency = 1f;

        originPosition = transform.localPosition;
        tick = Random.Range(0f, 2f * Mathf.PI);
        // 计算振幅
        amplitude = 2 * Mathf.PI / frequency;
        animate = playAwake;
    }

    public void Play()
    {
        transform.localPosition = originPosition;
        animate = true;
    }

    public void Stop()
    {
        transform.localPosition = originPosition;
        animate = false;
    }

    void FixedUpdate()
    {
        if (animate)
        {
            // 计算下一个时间量
            tick = tick + Time.fixedDeltaTime * amplitude;
            // 计算下一个偏移量
            var amp = new Vector3(Mathf.Cos(tick) * offset.x, Mathf.Sin(tick) * offset.y, 0);
            // 更新坐标
            transform.localPosition = originPosition + amp;
        }
    }
}