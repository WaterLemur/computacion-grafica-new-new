//Include guard

#ifndef LIGHTING_CORE //Preprocessor directive
#define LIGHTING_CORE

//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

void GetMainLight_float(float3 positionWS, out float3 directionWS, out float3 color, out float shadowAttenuation)
{
	#if defined(SHADERGRAPH_PREVIEW)
	directionWS = float3(1, 1, 0);
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
void SimpleLightAdditional_float(float2 UVSS, float3 normalWS, float3 viewDirWS, float3 positionWS, float roughness, out float3 lit)
{
	#if defined(SHADERGRAPH_PREVIEW)
	lit = 0;
	
	#else
	uint additionalLightCount = GetAdditionalLightsCount();
	
	#ifdef USE_CLUSTER_LIGHT_LOOP
	InputData inputData = (InputData)0;
	inputData.normalizedScreenSpaceUV = UVSS;
	inputData.positionWS = positionWS;
	inputData.normalWS = normalWS;
	#endif
	
	lit = 0;
	LIGHT_LOOP_BEGIN(additionalLightCount)
	Light light = GetAdditionalLight(lightIndex, positionWS, 1);
	//TODO get additional light index

	// Lambert
	float lambert = max(dot(light.direction, normalWS), 0);
	
	//Blinn-Phong
	float3 h = normalize(viewDirWS + light.direction);
	float blinnPhong = max(dot(h, normalWS), 0);
	float specularPower = lerp(200, 1, roughness);
	float specularCoefficiet = pow(1 - roughness, 2);
	
	//Lambert to Diffuse
	float3 diffuse = lambert * light.color * light.distanceAttenuation * light.shadowAttenuation;
	//Blinn-Phong to Specular
	float3 specular = pow(blinnPhong, specularPower) 
							* specularCoefficiet 
							* light.color 
							* light.distanceAttenuation 
							* light.shadowAttenuation;
	
	//Combined
	lit += diffuse + specular;
	
	LIGHT_LOOP_END
	#endif
}

void BlinnPhongAdditional_float(float2 UVSS, float3 normalWS, float3 viewDirWS, float3 positionWS, float roughness, out float3 lit)
{
	#if defined(SHADERGRAPH_PREVIEW)
	lit = 0;
	
	#else
	uint additionalLightCount = GetAdditionalLightsCount();
	
	#ifdef USE_CLUSTER_LIGHT_LOOP
	InputData inputData = (InputData)0;
	inputData.normalizedScreenSpaceUV = UVSS;
	inputData.positionWS = positionWS;
	inputData.normalWS = normalWS;
	#endif
	
	lit = 0;
	LIGHT_LOOP_BEGIN(additionalLightCount)
	Light light = GetAdditionalLight(lightIndex, positionWS, 1);
	//TODO get additional light index
	
	//Blinn-Phong
	float3 h = normalize(viewDirWS + light.direction);
	float blinnPhong = max(dot(h, normalWS), 0);
	float specularPower = lerp(200, 1, roughness);
	float specularCoefficiet = pow(1 - roughness, 2);
	
	//Blinn-Phong to Specular
	float3 specular = pow(blinnPhong, specularPower) 
							* specularCoefficiet 
							* light.color 
							* light.distanceAttenuation 
							* light.shadowAttenuation;
	
	//Combined
	lit += specular;
	
	LIGHT_LOOP_END
	#endif
}
#endif
