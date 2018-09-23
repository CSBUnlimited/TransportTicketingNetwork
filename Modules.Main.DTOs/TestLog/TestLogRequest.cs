using Common.Base.DTOs;
using Modules.Main.ViewModels;

namespace Modules.Main.DTOs.TestLog
{
    public class TestLogRequest : BaseRequest
    {
        public TestLogViewModel TestLogViewModel { get; set; }
    }
}
