using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Student_Services
{
    public interface IFileServices<T>
    {
        public Task<List<T>> ReadFileAsync(string filePath);
        public Task WriteFileAsync(List<T> data, string filePath);
    }
}
