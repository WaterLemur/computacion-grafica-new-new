#ifndef LIGHTING_CORE_HLSL
#define LIGHTING_CORE_HLSL

void GetMainLight_float(float3 positionWS, out float3 directionWS, out float3 color, out float shadowAttenuation)
{
#if defined(SHADERGRAPH_PREVIEW)
    directionWS = float3(1.0, 1.0, 1.0);
    color = float3(1.0, 1.0, 1.0);
    shadowAttenuation = 1.0;
#else
    float4 shadowCoord = TransformWorldToShadowCoord(positionWS);
    Light mainLight = GetMainLight(shadowCoord);
    directionWS = mainLight.direction;
    color = mainLight.color;
    shadowAttenuation = mainLight.shadowAttenuation;
#endif
}

#endif
