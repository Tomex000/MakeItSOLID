using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGenerator
{
    enum EFileFormat
    {
        other,
        tiff,
        jpg,
    }

    class OldFileGenerator
    {
        public bool ValidateFile(string path)
        {
            //to do
        }
        bool ValidateTIFF(string path)
        {
            return true;
        }

        bool ValidateJPG(string path)
        {
            return true;
        }
        EFileFormat GetFormat(string path)
        {
            return EFileFormat.jpg;
        }
    }
}
