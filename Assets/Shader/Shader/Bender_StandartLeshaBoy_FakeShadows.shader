Shader "Bender/StandartLeshaBoy_FakeShadows" {
	Properties {
		_Color ("Color", Vector) = (1,1,1,0)
		_MainTex ("MainTex", 2D) = "white" {}
		_Emission ("Emission", Range(0, 1)) = 0.7
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		[HideInInspector] __dirty ("", Float) = 1
		_ShadowFloorY ("Shadow Floor y", Float) = 0
		_ShadowDirX ("ShadowDirX", Range(-1, 1)) = 0
		_ShadowDirZ ("ShadowDirZ", Range(-1, 1)) = 0
		_ShadowColor ("ShadowColor", Vector) = (0.5,0.5,0.5,1)
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	//CustomEditor "ASEMaterialInspector"
}