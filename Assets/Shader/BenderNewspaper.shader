Shader "BenderNewspaper" {
	Properties {
		_MainTex ("MainTex", 2D) = "white" {}
		_Emission ("Emission", Range(0, 1)) = 0.7
		_Noise ("Noise", 2D) = "white" {}
		_Intensity ("Intensity", Range(0, 1)) = 0.2947477
		_Speed ("Speed", Range(0, 1)) = 0
		_Edge ("Edge", Range(0, 1)) = 0
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		[HideInInspector] __dirty ("", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	//CustomEditor "ASEMaterialInspector"
}