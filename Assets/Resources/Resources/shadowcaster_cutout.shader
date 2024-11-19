Shader "Hidden/VacuumShaders/Curved World/ShadowCaster Cutout" {
	Properties {
		[CurvedWorldLargeLabel] V_CW_Label_Albedo ("Albedo", Float) = 0
		_Color ("  Color", Vector) = (1,1,1,1)
		_MainTex ("  Map (RGB) Trans (A)", 2D) = "white" {}
		[CurvedWorldUVScroll] _V_CW_MainTex_Scroll ("    ", Vector) = (0,0,0,0)
		[CurvedWorldLargeLabel] V_CW_Label_Cutoff ("Cutout", Float) = 0
		_Cutoff ("  Alpha cutoff", Range(0, 1)) = 0.5
		[CurvedWorldRangeFade] V_CW_RangeFadeDrawer ("Range Fade", Float) = 0
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
}