using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileGenerator
{
    public enum EFileFormat
    {
        other,
        tiff,
        jpg,
    }

    public interface IValidate
    {
        bool Validate(string path);
    }

    public interface IInspect
    {
        EFileFormat GetFormat(string path);
    }
    public class OldFileGenerator
    {
        IInspect _inspector;
        public OldFileGenerator(IInspect inspector)
        {
            if (inspector == null) throw new ArgumentNullException(nameof(inspector));

            this._inspector = inspector;
        }
        public bool ValidateFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new Exception("empty path");
            }
            if (Directory.Exists(path))
            {
                throw new Exception("incorrect path");
            }

            EFileFormat format = _inspector.GetFormat(path);
            ValidatorFactory factory = new ValidatorFactory();
            IValidate validator = factory.GetValidator(format);
            return validator.Validate(path);
        }
    }

    public class FileInspector : IInspect
    {
        public EFileFormat GetFormat(string path)
        {
            return EFileFormat.jpg;
        }
    }

    public class TiffValidator : IValidate
    {
        public bool Validate(string path)
        {
            return true;
        }
    }
    public class JPGValidator : IValidate
    {
        public bool Validate(string path)
        {
            return true;
        }
    }
    public class OtherValidator : IValidate
    {
        public bool Validate(string path)
        {
            return false;
        }
    }

    public class ValidatorFactory
    {
        public IValidate GetValidator(EFileFormat type)
        {
            switch (type)
            {
                case EFileFormat.other:
                    return new OtherValidator();
                case EFileFormat.tiff:
                    return new TiffValidator();
                case EFileFormat.jpg:
                    return new JPGValidator();
                default:
                    throw new Exception("unknown format");
            }
        }
    }
}
