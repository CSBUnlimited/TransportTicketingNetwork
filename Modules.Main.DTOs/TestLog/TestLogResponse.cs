using System.Collections.Generic;
using Common.Base.DTOs;
using Modules.Main.ViewModels;

namespace Modules.Main.DTOs.TestLog
{
    public class TestLogResponse : BaseResponse
    {
        public IEnumerable<TestLogViewModel> TestLogViewModel { get; set; }
    }
}
