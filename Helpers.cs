using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharlieMadeAThing.QuantumSpook
{
    public static class Helpers
    {
        public static Color32 UIntToColor( uint number ) {
            var intBytes = System.BitConverter.GetBytes(number);
            return new Color32(intBytes[0], intBytes[1], intBytes[2], intBytes[3]);
        }
        
        public static uint ColorToUInt( Color32 color ) {
            var intBytes = new byte[] { color.r, color.g, color.b, color.a };
            return System.BitConverter.ToUInt32(intBytes, 0);
        }

        public static byte[] ToByteArray( this Color32 color ) {
            return new[] { color.r, color.g, color.b, color.a };
        }
        
        
    }
}
