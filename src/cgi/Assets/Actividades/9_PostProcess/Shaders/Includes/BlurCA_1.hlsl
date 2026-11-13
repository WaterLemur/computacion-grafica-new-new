#ifndef BLUR_CA_1
#define BLUR_CA_1

#ifndef SHADERGRAPH_PREVIEW
TEXTURE2D_X(_BlitTexture);
#endif

void RadialBlurChromaticAberrration_float(float2 pixelCoords, float pixelOffset, out float4 result)
{
    result = float4(0,0,0,0);
    #ifndef SHADERGRAPH_PREVIEW
    for (int y = 1; y >= -1; y--)
    {
        for(int x = -1; x <= 1; x++)
        {
            float2 sampleCoords = pixelCoords + float2(x, y) * pixelOffset;
            result += LOAD_TEXTURE2D_X_LOD(_BlitTexture, sampleCoords, 0) * 0.1111111111f;
        }
    }
    #endif
}

#endif