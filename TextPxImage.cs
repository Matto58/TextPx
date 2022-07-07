using System;
using System.Drawing.Imaging;

namespace TextPx
{
    public class TextPxImage
    {
        public Bitmap TPx_to_image(string contents)
        {
            string[] split = contents.Split(";");
            string[] metaD = split[0].Split(":");
            Bitmap bmp = new Bitmap(Convert.ToInt32(metaD[0]), Convert.ToInt32(metaD[1]));
            // Convert the rest of the string to pixels
            // Each pixel is represented by a string separated by a ";"
            // Where each string is a list of values separated by a ":"
            // Where each value is a number representing the color of the pixel
            // In the order: R, G, B, A
            // Example: "255:0:0:255;0:255:0:255;0:0:255:255;255:255:0:255;"
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    string[] pixel = split[y * bmp.Width + x + 1].Split(":");
                    bmp.SetPixel(
                        x, y,
                        Color.FromArgb(
                            Convert.ToInt32(pixel[3]),
                            Convert.ToInt32(pixel[0]),
                            Convert.ToInt32(pixel[1]),
                            Convert.ToInt32(pixel[2])
                        )
                    );
                }
            }
            return bmp;
        }
        public string Image_to_TPx(Bitmap img)
        {
            Bitmap CONT = img;
            string contents = CONT.Width + ":" + CONT.Height + ":0:0:0:255;";
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    contents += 
                        img.GetPixel(x, y).R + ":" +
                        img.GetPixel(x, y).G + ":" +
                        img.GetPixel(x, y).B + ":" +
                        img.GetPixel(x, y).A + ";";
                }
            }
            return contents;
        }
    }
}
