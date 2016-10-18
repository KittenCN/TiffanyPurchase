using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ZXing.QrCode;  
using ZXing;  
using ZXing.Common;  
using ZXing.Rendering;
using ByteMatrix = ZXing.Common.BitMatrix;

namespace BHair
{
    public class GetCode39
    {
        public Bitmap GetUnCodeBitmap(string UnCode)
        {
            EncodingOptions options = null;
            BarcodeWriter writer = null;
            options = new QrCodeEncodingOptions
            {  
                DisableECI = true,  
                CharacterSet = "UTF-8",  
                Width = 100,
                Height = 60
            };  
            writer = new BarcodeWriter();  
            writer.Format = BarcodeFormat.CODE_128;  
            writer.Options = options;
            Bitmap bitmap = writer.Write(UnCode);
            return bitmap;
        }
    }
}
