Shader "Hidden/VacuumShaders/Curved World/Outline" {
	Properties {
		_V_CW_OutlineColor ("Outline Color", Vector) = (0,0,0,1)
		_V_CW_OutlineWidth ("Outline width", Float) = 0.005
		[CurvedWorldBooleanToggle] _V_CW_OutlineSizeIsFixed ("Fixed Size", Float) = 0
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
}