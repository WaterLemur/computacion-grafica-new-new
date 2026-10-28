//Include guard

#ifndef LIGHTING_CORE //Preprocessor directive
#define LIGHTING_CORE

void GetMainLight_float(float3 positionWS, out float3 directionWS, out float3 color, out float shadowAttenuation)
{
	#if defined(SHADERGRAPH_PREVIEW)
	directionWS = float3(1, 1, -1);
	color = 1;
	shadowAttenuation = 1;
	#else
	float4 shadowCoord = TransformWorldToShadowCoord(positionWS);
	Light mainLight = GetMainLight(shadowCoord);

	directionWS = mainLight.direction;
	color = mainLight.color;
	shadowAttenuation = mainLight.shadowAttenuation;
	#endif
}
#endif
