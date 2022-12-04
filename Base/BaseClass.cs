namespace Base
{
    public abstract class BaseClass
    {
        private string _fileName { get; init; }
        public string input => ReadFile();
        public BaseClass(string fileName) => _fileName = _fileName;

        private string ReadFile()
        {
            return File.ReadAllText(_fileName);
        }
    }
}