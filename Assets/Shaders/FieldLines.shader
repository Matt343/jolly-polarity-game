Shader "Custom/FieldLines" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
    
		CGPROGRAM
		#pragma surface surf Unlit

		half4 LightingUnlit(SurfaceOutput s, half3 lightDir, half atten)
    	{
        	return half4(s.Albedo, s.Alpha);
    	}

		sampler2D _MainTex;
		float2 points[50];
		
		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
