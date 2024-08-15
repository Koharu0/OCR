using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tesseract;

namespace OCR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Tesseract()
        {
            public static void OCR(TextBox tessdata_path, TextBox image_Path, TextBox results)
            {
                string tessDataPath = tessdata_path.Text;
                string imagePath = image_Path.Text;
                
                try
                {
                    using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
                    {
                        using (var img = Pix.LoadFromFile(imagePath))
                        {
                            using (var page = engine.Process(img))
                            {
                                string text = page.GetText();
                                MessageBox.Show("Extracted Text: \n" + text);
                                results.Text = text;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                }
            }
        }

        public void btnTesseract_Click(object sender, RoutedEventArgs e)
        {
            Tesseract.OCR(tboxTessdataPath, tboxImgPath, tboxResults);
        }
    }
}