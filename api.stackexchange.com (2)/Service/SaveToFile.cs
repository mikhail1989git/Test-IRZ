using System;
using System.IO;
using System.Threading.Tasks;
using MessageBox = System.Windows.MessageBox;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace Service
{
    public class SaveToFile
    {
        public static async Task SaveFileAsync(string line)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                if ((bool)saveFileDialog1.ShowDialog())
                {
                    using (StreamWriter file = new StreamWriter(saveFileDialog1.FileName))
                    {
                        await file.WriteLineAsync(line);

                        MessageBox.Show($"Результаты сохранены");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи\n{ex.Message}");
            }
        }
    }
}
