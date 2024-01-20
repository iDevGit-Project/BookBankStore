using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FarhangbookStore.PublicExtentions
{
    public class ExtentionConvertImage
    {
        public void Image_resize(string input_Image_Path, string output_Image_Path, int new_Width, int new_height)
        {

            const long quality = 50L;

            Bitmap source_Bitmap = new Bitmap(input_Image_Path);


            //< create Empty Drawarea >

            var new_DrawArea = new Bitmap(new_Width, new_height);

            //</ create Empty Drawarea >

            using (var graphic_of_DrawArea = Graphics.FromImage(new_DrawArea))

            {

                //< setup >

                graphic_of_DrawArea.CompositingQuality = CompositingQuality.HighSpeed;

                graphic_of_DrawArea.InterpolationMode = InterpolationMode.HighQualityBicubic;

                graphic_of_DrawArea.CompositingMode = CompositingMode.SourceCopy;

                //</ setup >

                //< draw into placeholder >

                //*imports the image into the drawarea

                graphic_of_DrawArea.DrawImage(source_Bitmap, 0, 0, new_Width, new_height);

                //</ draw into placeholder >

                //--< Output as .Jpg >--

                using (var output = System.IO.File.Open(output_Image_Path, FileMode.Create))

                {

                    //< setup jpg >

                    var qualityParamId = System.Drawing.Imaging.Encoder.Quality;

                    var encoderParameters = new EncoderParameters(1);

                    encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);

                    //</ setup jpg >

                    //< save Bitmap as Jpg >

                    var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                    new_DrawArea.Save(output, codec, encoderParameters);

                    //resized_Bitmap.Dispose ();

                    output.Close();

                    //</ save Bitmap as Jpg >

                }

                //--</ Output as .Jpg >--

                graphic_of_DrawArea.Dispose();

            }

            source_Bitmap.Dispose();

            //---------------</ Image_resize() >---------------

        }
    }
}
