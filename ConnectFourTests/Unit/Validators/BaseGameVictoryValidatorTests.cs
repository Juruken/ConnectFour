using System;
using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;
using ConnectFour.Validators;

namespace ConnectFourTests.Unit.Validators
{
    public class BaseGameVictoryValidatorTests : BaseGameTests
    {
        protected IGameValidator m_GameVictoryValidator;
        protected Players m_WinningPlayer = Players.Yellow;
        protected Players m_LosingPlayer = Players.Red;
    }
}
