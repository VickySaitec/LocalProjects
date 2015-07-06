using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.QRCode.Codec;

namespace SaitecSolutionLib
{
    public class QRCodeGenerater
    {
        static string Final;
        System.Drawing.Image image;
        System.IO.MemoryStream imageStream;
        byte[] imageBytes;
        System.IO.Stream stream;

        public QRCodeGenerater(string qrstr)
        {
            Final = qrstr;
        }
        public byte[] CodeGenerator()
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            String encoding = Final;
            if (encoding == "Byte")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            }
            else if (encoding == "AlphaNumeric")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
            }
            else if (encoding == "Numeric")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
            }

            try
            {
                int version = Convert.ToInt16(15);
                qrCodeEncoder.QRCodeVersion = version;
            }
            catch (Exception)
            {
                //ex.Message("Invalid version !");
            }

            string errorCorrect = "L";
            if (errorCorrect == "L")
            {
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            }

            Bitmap bt = qrCodeEncoder.Encode(encoding);
            System.IO.MemoryStream stream = new System.IO.MemoryStream();

            image = bt;
            imageStream = new System.IO.MemoryStream();
            image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg); // Use whatever format your image is.
            imageBytes = imageStream.ToArray();
            return imageBytes;
        }
    }
}
