using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;

namespace Ingpal.BusinessStore.Infrastructure
{
  public  class BarCode
    {
        public static Bitmap CreatePictureBarCode(int width,int height,string barCodeString)
        {
            // 1.设置条形码规格
            EncodingOptions encodeOption = new EncodingOptions();
            encodeOption.Height = height; // 必须制定高度、宽度
            encodeOption.Width = width;
            encodeOption.Margin = 0;
            // 2.生成条形码图片并保存
            ZXing.BarcodeWriter wr = new BarcodeWriter();
            wr.Options = encodeOption;
            wr.Format = BarcodeFormat.CODE_128; //  条形码规格：EAN13规格：12（无校验位）或13位数字
            Bitmap img = wr.Write(barCodeString); // 生成图片
            return img;
        }
    }
}
