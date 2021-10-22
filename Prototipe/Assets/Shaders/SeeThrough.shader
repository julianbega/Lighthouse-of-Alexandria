Shader "Custom/SeeThrough"
{
    Properties{
	}
    SubShader
    {
        Tags { "Queue"="Geometry-1" }
        ColorMask 0

        Zwrite Off

		Stencil{
		Ref 1
		Comp Always
		Pass Replace
		}
        
		CGPROGRAM
        #pragma surface surf Lambert
		
        struct Input
        {
            float2 worldPos;
        };

		
        void surf (Input IN, inout SurfaceOutput o)
        {
            
            o.Albedo = fixed4(1,1,1,1);
        }

			
        ENDCG

		
    }
    FallBack "Diffuse"
}
