using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagerFile
{
    [ComVisible(true)]
    public class ScriptManager
    {
        // Sự kiện được kích hoạt khi có sự kiện click
        public event Action<string> ElementClicked;

        // Phương thức để xử lý thông tin trả về từ JavaScript
        public void Notify(string elementInfoJson)
        {
            ElementClicked?.Invoke(elementInfoJson);
        }
    }
}
