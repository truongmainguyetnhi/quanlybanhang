using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webbanhang
{
    internal class Common
    {
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            if (imageIn == null)
            {
                // Thực hiện xử lý hoặc hiển thị cảnh báo ở đây
                MessageBox.Show("Hình ảnh không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            using (var ms=new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0)
            {
                // Thực hiện xử lý hoặc hiển thị cảnh báo ở đây
                MessageBox.Show("Dữ liệu hình ảnh không hợp lệ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            using (var ms = new MemoryStream(byteArrayIn))
            {
                var returnImage= Image.FromStream(ms);
                return returnImage;
            }
        }

            
    }
}
