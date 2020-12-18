using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public class Files
    {
        public static String filePath="";
        public string SaveFile()
        {
           
            SaveFileDialog saveFile = new SaveFileDialog();
            String filename;
            saveFile.Filter = "DataBase file | *.db";
            saveFile.DefaultExt = "db";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                filename = saveFile.FileName;
                filePath = Path.GetFullPath(saveFile.FileName);

            }
            return filePath;
        }
        public string OpenFile()
        {
           
            String filename = null;
            filePath = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "DataBase file | *.db";
            openFile.DefaultExt = "db";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filename = openFile.FileName;
                filePath = Path.GetFullPath(openFile.FileName);

            }
            return filePath;
        }
    }
}
