using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace YiSha.Util
{
    public class QrCoderHelper
    {
        #region 普通二维码
        /// <summary>
        /// 普通二维码
        /// </summary>
        /// <param name="url">存储内容</param>
        /// <param name="pixel">像素大小</param>
        /// <returns></returns>
        public static Bitmap GetPTQRCode(string url, int pixel)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData codeData = generator.CreateQrCode(url, QRCodeGenerator.ECCLevel.M, true);
            QRCoder.QRCode qrcode = new QRCoder.QRCode(codeData);
            Bitmap qrImage = qrcode.GetGraphic(pixel, Color.Black, Color.White, true);
            return qrImage;
        }
        #endregion
    }
}
