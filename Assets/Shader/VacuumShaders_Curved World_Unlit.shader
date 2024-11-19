Shader "VacuumShaders/Curved World/Unlit" {
	Properties {
		[CurvedWorldGearMenu] V_CW_Label_Tag ("", Float) = 0
		[CurvedWorldLabel] V_CW_Label_UnityDefaults ("Default Visual Options", Float) = 0
		[CurvedWorldLargeLabel] V_CW_Label_Modes ("Modes", Float) = 0
		[CurvedWorldRenderingMode] V_CW_Rendering_Mode ("  Rendering", Float) = 0
		[CurvedWorldTextureMixMode] V_CW_Texture_Mix_Mode ("  Texture Mix", Float) = 0
		[CurvedWorldLargeLabel] V_CW_Label_Albedo ("Albedo", Float) = 0
		_Color ("  Color", Vector) = (1,1,1,1)
		_MainTex ("  Map (RGB) RefStr (A)", 2D) = "white" {}
		[CurvedWorldUVScroll] _V_CW_MainTex_Scroll ("    ", Vector) = (0,0,0,0)
		[CurvedWorldLabel] V_CW_Label_UnityDefaults ("Unity Advanced Rendering Options", Float) = 0
		[HideInInspector] _V_CW_IncludeVertexColor ("", Float) = 0
		[HideInInspector] _V_CW_Rim_Color ("", Vector) = (1,1,1,1)
		[HideInInspector] _V_CW_Rim_Bias ("", Range(-1, 1)) = 0.2
		[HideInInspector] _V_CW_Rim_Power ("", Range(0.5, 8)) = 3
		[HideInInspector] _EmissionMap ("", 2D) = "white" {}
		[HideInInspector] [HDR] _EmissionColor ("", Vector) = (1,1,1,1)
		[HideInInspector] _V_CW_IBL_Intensity ("", Float) = 1
		[HideInInspector] _V_CW_IBL_Contrast ("", Float) = 1
		[HideInInspector] _V_CW_IBL_Cube ("", Cube) = "" {}
		[HideInInspector] _V_CW_IBL_Matcap ("", 2D) = "Gray" {}
		[HideInInspector] _V_CW_ReflectColor ("", Vector) = (1,1,1,1)
		[HideInInspector] _V_CW_ReflectStrengthAlphaOffset ("", Range(-1, 1)) = 0
		[HideInInspector] _V_CW_Cube ("", Cube) = "_Skybox" {}
		[HideInInspector] _V_CW_Fresnel_Bias ("", Range(-1, 1)) = 0
		[HideInInspector] _V_CW_NormalMapStrength ("", Float) = 1
		[HideInInspector] _V_CW_NormalMap ("", 2D) = "bump" {}
		[HideInInspector] _V_CW_NormalMap_UV_Scale ("", Float) = 1
		[HideInInspector] _V_CW_SecondaryNormalMap ("", 2D) = "" {}
		[HideInInspector] _V_CW_SecondaryNormalMap_UV_Scale ("", Float) = 1
		[PerRendererData] _FlipScale ("FlipScale", Vector) = (1,1,1,1)
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
	//CustomEditor "CurvedWorld_Material_Editor"
}