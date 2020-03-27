Shader "Unlit/WallShader"
{
    Properties
    {
        _inColor("inColor",Color) = (1,1,1,1)
        _outColor("outColor",Color) = (0,0,0,1)
    }
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 100

		Pass //1
		{
		    Cull Front  //裏面の描画

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION; //多分頂点座標
				float3 normal : NORMAL; //多分法線
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			float4 _outColor;
			
			v2f vert (appdata v)
			{

				v2f o;
				v.vertex += float4(v.normal/2000, 0); //法線方向に膨張(3次元, 1次元？)
				o.vertex = UnityObjectToClipPos(v.vertex); //頂点座標をワールド座標に変換？？？
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = fixed4(_outColor); //周りの色
				return col;
			}
			ENDCG
		}

		Pass //トゥーン表示
		{
		Cull Back

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag

		#include "UnityCG.cginc"

		struct appdata
		{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
		};

		struct v2f
		{
		float4 vertex : SV_POSITION;
		float3 normal : NORMAL;
		};

		float4 _inColor;

		v2f vert (appdata v)
		{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.normal = UnityObjectToWorldNormal(v.normal);
		return o;
		}

		fixed4 frag (v2f i) : SV_Target
		{
		fixed4 col = fixed4(_inColor);
		return col;
		}
		ENDCG
		}//pass

	}
}
