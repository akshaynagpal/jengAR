/*==============================================================================
Copyright (c) 2012-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
==============================================================================*/

Shader "Custom/Outline" 
{
	Properties 
	{
		_SilhouetteSize ("Size", Float) = 0.0
		_SilhouetteColor ("Color", Color) = (1,1,1,1)
	}
	
	CGINCLUDE
	#include "UnityCG.cginc"

	struct v2f 
	{
		float4 position : POSITION;
		float4 color : COLOR;
	};

	struct vertIn 
	{
		float4 position : POSITION;
		float3 normal : NORMAL;
	};

	uniform float _SilhouetteSize;
	uniform float4 _SilhouetteColor;
	
	ENDCG

	SubShader 
	{
		Tags { "Queue" = "Transparent" }
		
		Pass 
		{ 
			Cull Back
			Blend Zero One
		}
		
		Pass 
		{
			Cull Front

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			v2f vert(vertIn input) 
			{
				v2f output;
				// unmodified projected position of the vertex
				output.position = mul(UNITY_MATRIX_MVP, input.position);
				output.color = _SilhouetteColor;

				// calculate silhouette in image space
				float2 silhouette   = TransformViewToProjection(mul((float3x3)UNITY_MATRIX_IT_MV, input.normal).xy) * _SilhouetteSize;

				// add silhouette offset
				output.position.xy += output.position.z *  silhouette;
				
				return output;
			}

			half4 frag(v2f input) :COLOR 
			{
				return input.color;
			}
			ENDCG
		}


	}
	
	Fallback "Diffuse"
}