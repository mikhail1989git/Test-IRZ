using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Services.Common
{
    public class SaveToFile
    {
        public static async Task SaveFileAsync(string line)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";

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
