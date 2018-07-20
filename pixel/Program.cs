using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace pixel
{
    class Program
    {
        static void Main(string[] args)
        {
            Image img = Image.FromFile("../../img/masked_dog.png");//画像データのオブジェクト
            Bitmap bitmap = new Bitmap(img);                  //画像データのビットマップ
            Bitmap newbitmap = new Bitmap(img);
            Bitmap bitmap_twiceSize = new Bitmap(img, new Size(img.Width*2, img.Height*2));
            Bitmap bitmap_Mosaic = new Bitmap(img, new Size(img.Width, img.Height));
            int width = img.Width;                            //画像の幅
            int height = img.Height;                          //画像の高さ
            System.Console.Write("幅　=" + width + '\n');
            System.Console.Write("高さ=" + height + '\n');

            Color[] colors = {  Color.Gold,Color.Blue,Color.Yellow,Color.Green,Color.Pink};

            for (int num = 0; num < colors.Length; num++)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        Color color = bitmap.GetPixel(i, j);
                        Color newColor;
                        if (color.R == 0 && color.B == 0 && color.G == 0)
                        {
                            newColor = colors[num];
                            newColor = Color.FromArgb(newColor.R / 2, newColor.G / 2, newColor.B / 2);
                        }
                        else newColor = Color.FromArgb(color.R, color.G, color.B);
                        newbitmap.SetPixel(i, j, newColor);
                    }
                }
                newbitmap.Save("../../img/image_pale_"+colors[num].ToString()+".png");
            }
        }
    }
}
