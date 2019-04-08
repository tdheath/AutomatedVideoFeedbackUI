using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wireframe_GUI
{
    /// <summary>
    /// Class which has a window that displays images to the user. 
    /// This includes a list of thumbnails for quick navigation.
    /// </summary>
    public partial class ImageViewer : Window
    {
        private List<string> images = new List<string>();
        private int curImgIdx;

        /* ImageViewer
         * Description: Constructor for the window.
         * Args: imageDir - The directory where the images are stored.
         */
        public ImageViewer(string imageDir)
        {
            InitializeComponent();

            curImgIdx = 0;

            //Grab the template from the xaml definition, to be applied to the thumbnails
            ControlTemplate template = (ControlTemplate)this.FindResource("thumbTemplate");

            //Populate all of the thumbnail images
            foreach(string file in Directory.GetFiles(imageDir, "*.jpg").ToList())
            {
                Button newThumb = new Button();
                newThumb.Template = template;
                newThumb.Tag = file;
                newThumb.Click += thumbBtn_Click;
                thumbsList.Children.Add(newThumb);

                images.Add(file);
            }

            //Simulate a click on the first thumbnail to start
            thumbsList.Children[curImgIdx].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        /* leftChangeBtn_Click
         * Description: Event handler for clicking the left nav arrow on the image.
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */
        private void leftChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            //If at 0 already, loop around, otherwise just subtract 1 from the selection
            if (curImgIdx <= 0)
            {
                curImgIdx = images.Count - 1;
            }
            else
            {
                curImgIdx--;
            }

            thumbsList.Children[curImgIdx].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        /* rightChangeBtn_Click
         * Description: Event handler for clicking the right nav arrow on the image.
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */
        private void rightChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            //If at the end already, loop around, otherwise just add 1 to the selection
            if (curImgIdx >= images.Count - 1)
            {
                curImgIdx = 0;
            }
            else
            {
                curImgIdx++;
            }

            thumbsList.Children[curImgIdx].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        /* thumbBtn_Click
         * Description: Event handler for clicking a thumbnail image
         * Args: sender - The object where the event originated
         *       e - The event arguments
         */
        private void thumbBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Button)thumbsList.Children[curImgIdx]).BorderBrush = new SolidColorBrush(Colors.DarkGray);
            ((Button)thumbsList.Children[curImgIdx]).BorderThickness = new Thickness(5);

            curImgIdx = thumbsList.Children.IndexOf(sender as UIElement);

            //TODO: makes no sense, but the below doesn't work
            Button b = thumbsList.Children[curImgIdx] as Button;
            b.BorderBrush = new SolidColorBrush(Colors.Cornsilk);
            b.BorderThickness = new Thickness(3);
            currentImage.Source = new BitmapImage(new Uri(images[curImgIdx]));
        }
    }
}
