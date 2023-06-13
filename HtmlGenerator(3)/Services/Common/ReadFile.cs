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
    public class ReadFile
    {
        public static async Task<string> ReadAsync() {

            try
            {
                OpenFileDialog open = new OpenFileDialog();

                if ((bool)open.ShowDialog())
                {
                    using (StreamReader file = new StreamReader(open.FileName))
                    {
                        return await file.ReadToEndAsync();
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка чтения\n{ex.Message}");
                return string.Empty;
            }

        }

    }
}
