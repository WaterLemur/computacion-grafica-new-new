
#ifndef SCREEN_SHAKE
#define SCREEN_SHAKE

#ifndef SHADERGRAPH_PREVIEW
TEXTURE2D_X(_BlitTexture);
#endif

void ScreenShake_float(
    float2 pixelCoords,
    float intensity,
    float speed,
    float time,
    out float4 result)
{
    result = float4(0, 0, 0, 1);

    #ifndef SHADERGRAPH_PREVIEW

    float2 shakeOffset;

    shakeOffset.x = sin(time * speed * 1.7) * intensity;
    shakeOffset.y = cos(time * speed * 2.3) * intensity;

    float2 sampleCoords = pixelCoords + shakeOffset;

    result = LOAD_TEXTURE2D_X_LOD(
        _BlitTexture,
        sampleCoords,
        0
    );

    #endif
}

#endif
