using AutoMapper;
using Common.Base.Services;
using Modules.Main.Core.DataAccess;
using Modules.Main.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Services
{
    public class JourneyService : BaseService, IJourneyService
    {
        private IMainUnitOfWork _mainUnitOfWork;
        private IMapper _mapper;
    }
}
